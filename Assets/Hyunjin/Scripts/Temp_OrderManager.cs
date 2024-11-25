using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_OrderManager : MonoBehaviour
{
    public static Temp_OrderManager Instance { get; private set; }
    
    public GameObject orderUIPrefab; // OrderUI 프리팹
    public Transform orderUIBox;       // OrderBox의 Transform
    private int nextOrderId = 1;     // 주문 ID 생성기

    private List<Order> orders = new List<Order>(); // 모든 주문 데이터 저장
    private Dictionary<int, OrderUI> activeOrders = new Dictionary<int, OrderUI>(); // 활성화된 주문 UI

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // 주문 추가
    public void AddOrder(string menuName, int tableNumber, float duration) {
        Order newOrder = new Order(nextOrderId++, menuName, tableNumber, duration);
        orders.Add(newOrder); // 주문리스트에 추가

        // UI 생성 및 초기화
        GameObject newOrderUIObject = Instantiate(orderUIPrefab, orderUIBox);
        OrderUI orderUI = newOrderUIObject.GetComponent<OrderUI>();
        if (orderUI != null) {
            orderUI.Initialize(newOrder);
            activeOrders[newOrder.orderId] = orderUI;
        }
    }

    // 주문 삭제
    public void RemoveOrder(int orderId) {
        // 데이터에서 제거
        orders.RemoveAll(o => o.orderId == orderId);

        // UI에서 제거
        if (activeOrders.TryGetValue(orderId, out OrderUI orderUI)) {
            orderUI.DestroyUI(); // UI 삭제
            activeOrders.Remove(orderId); // 딕셔너리에서 제거
        }
        else {
            Debug.LogWarning($"Order with ID {orderId} not found in activeOrders.");
        }
    }

    // 프레임마다 모든 주문 업데이트
    void Update() {
        float deltaTime = Time.deltaTime;

        for (int i = orders.Count - 1; i >= 0; i--) {
            Order order = orders[i];

            // 타임 슬라이더 업데이트
            if (activeOrders.TryGetValue(order.orderId, out OrderUI orderUI)) {
                orderUI.UpdateTime(deltaTime);

                if (orderUI.IsExpired()) { // 시간 만료된 주문 처리
                    RemoveOrder(order.orderId);
                }
            }
        }
    }
}
