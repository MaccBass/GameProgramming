using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp_OrderManager : MonoBehaviour
{
    public static Temp_OrderManager Instance { get; private set; }
    
    public GameObject orderUIPrefab; // OrderUI 프리팹
    public Transform orderUIBox;       // OrderBox의 Transform
    public List<Order> orderList = new List<Order>(); // 모든 주문 데이터 저장

    private int nextOrderId = 1;     // 주문 ID 생성기
    private float orderDuration = 10f; // 주문 제한시간

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Update() { // 모든 주문들의 제한시간 및 UI 관리
        float currentTime = Time.time;

        // orderList 순회하면서 status가 served/canceled가 아닌 주문들을 관리
        foreach(Order o in orderList) {
            if (o.status == OrderStatus.SERVED || o.status == OrderStatus.CANCELED)
                continue;
            
            Slider timeSlider = o.orderUI.GetComponentInChildren<Slider>();
            float elapsedTime = currentTime - o.orderTime;
            float remainingTime = orderDuration - elapsedTime;
            timeSlider.value = remainingTime / orderDuration;

            if (o.status == OrderStatus.ORDERED && remainingTime / orderDuration < 0.2) { // 지연 시
                o.status = OrderStatus.DELAYED;
                o.customer.DelayOrder(o.menu.itemName);
            }

            if(remainingTime <= 0) { // 시간 초과 시
                o.status = OrderStatus.CANCELED;
                o.customer.CancleOrder(o.menu.itemName);
                Destroy(o.orderUI, 1.5f);
            }
        }
    }

    // 주문 추가
    public void AddOrder(Table table, Customer customer, Recipe menu) {
        // UI 생성
        GameObject orderUI = Instantiate(orderUIPrefab, orderUIBox);
        orderUI.GetComponentInChildren<Text>().text = $"{menu.itemName}";
        orderUI.GetComponentsInChildren<Text>()[1].text = $"테이블{table.id}";
        Slider timeSlider = orderUI.GetComponentInChildren<Slider>();
        timeSlider.maxValue = 1;
        timeSlider.value = timeSlider.maxValue;

        Order newOrder = new Order(nextOrderId++, table, customer, menu, Time.time, orderUI);
        orderList.Add(newOrder);
    }
}
