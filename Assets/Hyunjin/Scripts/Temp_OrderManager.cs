using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp_OrderManager : MonoBehaviour
{
    public static Temp_OrderManager Instance { get; private set; }
    
    public GameObject orderUIPrefab; // OrderUI 프리팹
    public Transform orderUIBox;       // OrderBox의 Transform
    public List<Order> orderList; // 모든 주문 데이터 저장

    private int nextOrderId = 1;     // 주문 ID 생성기
    private float orderDuration = 50f; // 주문 제한시간

    //종 오디오
    public AudioSource BellSource;
    public AudioClip Bellclip;

    //식사 사운드
    public AudioSource restaurantSource;
    public AudioClip restaurantClip;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        orderList = new List<Order>();
    }

    void Update() { // 모든 주문들의 제한시간 및 UI 관리
        float currentTime = Time.time;

        // orderList 순회하면서 주문들을 관리
        foreach(Order o in orderList) {
            if ((o.status == OrderStatus.SERVED || o.status == OrderStatus.CANCELED)) { 
                if (o.orderUI != null) {
                    Destroy(o.orderUI, 1.5f);
                    o.orderUI = null;
                }
                continue;
            }
            
            Slider timeSlider = o.orderUI.GetComponentInChildren<Slider>();
            float elapsedTime = currentTime - o.orderTime;
            float remainingTime = orderDuration - elapsedTime;
            timeSlider.value = remainingTime / orderDuration;

            if (o.status == OrderStatus.ORDERED && remainingTime / orderDuration < 0.2) { // 지연 시
                o.status = OrderStatus.DELAYED;
                o.customer.DelayOrder(o.orderItem.itemName);
            }

            if(remainingTime <= 0) { // 시간 초과 시
                o.status = OrderStatus.CANCELED;
                o.customer.CancelOrder(o.orderItem.itemName);
                Destroy(o.orderUI, 1.5f);
                o.orderUI = null;
            }
        }
    }

    // 주문 추가
    public void AddOrder(Table table, Customer customer, Item orderItem) {
        // UI 생성
        GameObject orderUI = Instantiate(orderUIPrefab, orderUIBox);
        orderUI.GetComponentInChildren<Text>().text = $"{orderItem.itemName}";
        orderUI.GetComponentsInChildren<Text>()[1].text = $"테이블{table.id}";
        Slider timeSlider = orderUI.GetComponentInChildren<Slider>();
        timeSlider.maxValue = 1;
        timeSlider.value = timeSlider.maxValue;

        Order newOrder = new Order(nextOrderId++, table, customer, orderItem, Time.time, orderUI);
        orderList.Add(newOrder);
        Managers.Employee.AddOrder(newOrder);

        //사운드 재생
        PlayBellSound(Bellclip);

    }

    public bool ServeOrder(Item servedItem, Customer customer) { // Recipe->Item으로 바꿔야됨
        foreach (Order order in orderList) {
            // 주문된 아이템과 서빙하려는 아이템 이름이 같고, 해당 주문의 고객이 매개변수로 받은 고객과 같은지 확인
            if (order.orderItem.itemName == servedItem.itemName && order.customer == customer &&
                    order.status != OrderStatus.SERVED && order.status != OrderStatus.CANCELED) {
                order.status = OrderStatus.SERVED;
                customer.RecieveServedOrder(servedItem); // 고객에게 서빙

                //사운드 재생
                PlayRestaurantSound(restaurantClip);
                return true; // 성공적으로 서빙
            }
        }
        Debug.Log("Serve Order Failed : " + servedItem.itemName);
        return false; // 서빙 실패 (주문 목록에 없거나, 이미 서빙됐거나, 다른 고객의 주문)
    }

    private void PlayRestaurantSound(AudioClip clip)
    {
        if (clip != null)
        {
            restaurantSource.clip = clip;
            restaurantSource.Play();
            Invoke("StopRestaurantSound", 1.0f);
        }
    }
    private void PlayBellSound(AudioClip clip)
    {
        if (clip != null)
        {
            restaurantSource.clip = clip;
            restaurantSource.Play();
            Invoke("StopBellSound", 1.0f);
        }
    }
    private void StopRestaurantSound()
    {
        BellSource.Stop();
        restaurantSource.Stop();
    }
    private void StopBellSound()
    {
        BellSource.Stop();
        restaurantSource.Stop();
    }
}
