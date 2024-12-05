using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerStatus {
    PREORDER,
    WAITING,
    ANGRY,
    EATING,
    DEPARTED
}

public class Customer : MonoBehaviour
{
    private CustomerType type;
    private Table table;
    private float stayDuration;
    private CustomerStatus status;
    private int totalPayment;
    private int totalCS;

    public void Initialize(CustomerType type, Table table, int groupSize, float stayDuration) {
        this.type = type;
        this.table = table;
        this.stayDuration = stayDuration;
        this.status = CustomerStatus.PREORDER;
        this.totalPayment = 0;
        this.totalCS = 5;

        for (int i = 0; i < groupSize; i++) { // 손님을 의자에 앉히고 리스트에 추가
            GameObject customerPrefab = type.prefabs[Random.Range(0, type.prefabs.Count)];
            GameObject customerObj = Instantiate(customerPrefab, table.chairs[i].position, Quaternion.identity);
            if (i % 2 == 1) { // 홀수 의자일 경우 좌우 반전
                Vector3 scale = customerObj.transform.localScale;
                scale.x *= -1;
                customerObj.transform.localScale = scale;
            }
        }
    }
    
    public void GetDish(int payment, int cs) { // 플레이어가 서빙할 때 직접 호출
        totalPayment += payment;
        totalCS += cs;
    }

    private void Order() {
        // 랜덤 주문
        // table 상태 변환 필요

        // Temp_OrderManager.Instance.addOrder(table, this, menu);
    }

    private void Leave() {
        // table 상태 변환 필요
        Temp_UIManager.Instance.ShowPaymentSatisfaction(table.transform.position, totalPayment, totalCS);
        Destroy(gameObject);
    }
}
