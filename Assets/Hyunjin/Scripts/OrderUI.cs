using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public Text menuNameText;
    public Text tableNumberText;
    // public Text customerNameText;
    public Slider timeBar;

    // UI 초기화
    public void Initialize(Order order)
    {
        menuNameText.text = $"메뉴: {order.menuName}";
        tableNumberText.text = $"테이블: {order.tableNumber}";
        // customerNameText.text = $"손님: {order.customerName}";
        timeBar.maxValue = order.totalTime;
        timeBar.value = order.totalTime;
    }

    // 남은 시간 업데이트
    public void UpdateTime(float deltaTime) {
        timeBar.value = Mathf.Max(timeBar.value - deltaTime, 0); // 시간 감소 및 슬라이더 갱신
    }

    public bool IsExpired()
    {
        return timeBar.value <= 0;
    }

    // 삭제 요청 시 호출
    public void DestroyUI() {
        Destroy(gameObject); // UI 오브젝트 삭제
    }
}
