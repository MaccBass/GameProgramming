using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp_UIManager : MonoBehaviour
{
    public static Temp_UIManager Instance { get; private set; }

    // top area
    public Text dayText;
    public Text revenueText;
    public Slider timeSlider;
    public Button pauseButton;
    public Button ResumeButton;
    public GameObject PauseMenu;
    // customer UI
    public GameObject reviewUIPrefab;
    // order list UI
    // public Transform orderUIBox;
    // public GameObject orderUIPrefab;
    // private Dictionary<int, GameObject> orderUIObjects = new Dictionary<int, GameObject>(); // 주문 UI 관리
    // public ScrollRect scrollRect;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // top area
    public void UpdateDay(int day) {
        dayText.text = $"DAY {day}";
    }
    public void UpdateDailyRevenue(int revenue) {
        revenueText.text = $"{revenue}원";
    }
    public void UpdateTimeBar(float progress) {
        timeSlider.value = progress;
    }
    public void OnPauseButtonClicked() {
        Temp_GameManager.Instance.PauseGame();
        showPauseMenu();
    }
    public void OnResumeButtonClicked() {
        Temp_GameManager.Instance.ResumeGame();
        hidePauseMenu();
    }
    public void showPauseMenu() {
        Debug.Log("showPausesMenu()");
        PauseMenu.SetActive(true);
    }
    public void hidePauseMenu() {
        PauseMenu.SetActive(false);
    }

    // customer UI
    public void ShowPaymentSatisfaction(Vector3 position, int payment, int satisfaction) {
        GameObject reviewUI = Instantiate(reviewUIPrefab, position, Quaternion.identity);
        Text[] reviewTexts = reviewUI.GetComponentsInChildren<Text>();
        reviewTexts[0].text = payment + "원";
        reviewTexts[1].text = satisfaction + "점";
        Destroy(reviewUI, 3f);
    }

    // // order list UI
    // public void AddOrderToUI(Order order) {
    //     if (OrderUIObjects.ContainsKey(order.orderId)) {
    //         Debug.LogWarning($"Order {order.orderId} already exists in UI");
    //         return;
    //     }
    //     GameObject newOrder = Instantiate(orderUIPrefab, orderUIBox);
    //     OrderUI orderUI = newOrder.GetComponent<OrderUI>(); //????

    //     if (orderUI != null) {
    //         OrderUI.Initialize(order);
    //         OrderUIObjects[order.orderId] = newOrder;
    //     }
    // }
    // public void RemoveOrderFromUI(int orderId) {
    //     if (orderUIDict.TryGetValue(orderId, out GameObject orderUIObject)) {
    //         Destroy(orderUIObject); // UI 오브젝트 삭제
    //         orderUIDict.Remove(orderId); // 딕셔너리에서 제거
    //         Debug.Log($"Order UI {orderId} removed");
    //     }
    //     else
    //         Debug.LogWarning($"Order {orderId} not found in UI");
    // }
}
