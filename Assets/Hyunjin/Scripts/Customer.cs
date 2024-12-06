using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private CustomerType type;
    private Table table;
    private float stayDuration;
    private float timeSpent = 0;
    private float eatTimer = 0;
    private bool isEating = false;
    private int ordersPending = 0; // 대기 중인 주문 수

    private int totalPayment;
    private int totalCS;

    public void Initialize(CustomerType type, Table table, int groupSize, float stayDuration) {
        this.type = type;
        this.table = table;
        this.stayDuration = stayDuration;
        this.timeSpent = 0;
        this.isEating = false;
        this.eatTimer = 0;
        this.totalPayment = 0;
        this.totalCS = 5;

        for (int i = 0; i < groupSize; i++) { // 손님을 의자에 앉히고 리스트에 추가
            GameObject customerPrefab = type.prefabs[Random.Range(0, type.prefabs.Count)];
            GameObject customerObj = Instantiate(customerPrefab, this.table.chairs[i].position + new Vector3(0.224f, 0.65f, 0f), Quaternion.identity, this.transform);
            if (i % 2 == 1) { // 홀수 의자일 경우 좌우 반전
                Vector3 scale = customerObj.transform.localScale;
                scale.x *= -1;
                customerObj.transform.localScale = scale;
                customerObj.transform.position += new Vector3(-0.448f, 0, 0);
            }
        }
        Debug.Log($"INITIALIZED  :  {this.table.id}, {timeSpent}, {this.stayDuration}, {ordersPending}, {isEating}");
    }

    public void Update() {
        timeSpent += Time.deltaTime;

        if (isEating) {
            eatTimer += Time.deltaTime;
            if (eatTimer >= 3f) {
                isEating = false;
                eatTimer = 0;
            }
        }
        
        // 체류시간 지나고, 주문이 없고, 식사중이 아닐 때 퇴장
        if (timeSpent >= stayDuration && ordersPending == 0 && !isEating) {
            Leave();
        }
    }
    
    public void CompleteOrder(int payment, int cs) { // 플레이어가 서빙할 때 직접 호출
        Debug.Log($"completeOrder : {table.id} ({payment}, {cs})");
        ordersPending--;
        isEating = true;
        eatTimer = 0;

        totalPayment += payment;
        totalCS += cs;
    }

    private void Order() {
        Debug.Log($"Order : {table.id}");
        // 랜덤 주문
        // table 상태 변환 필요
        
        ordersPending++;
        // Temp_OrderManager.Instance.addOrder(table, this, menu);
    }

    private void Leave() {
        Debug.Log($"Leave : {table.id}");

        // table 상태 변환 필요
        Temp_UIManager.Instance.ShowPaymentSatisfaction(table.transform.position, totalPayment, totalCS);
        table.status = TableStatus.NEEDTOCLEAN;
        Destroy(gameObject);
    }
}
