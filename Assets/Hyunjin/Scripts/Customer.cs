using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private CustomerType type;
    private Table table;
    private float stayDuration;
    private float orderInterval;
    private float timeSpent = 0;
    private float orderTimer = 0;
    private float eatTimer = 0;
    private bool isEating = false;
    private int ordersPending = 0; // 대기 중인 주문 수

    public int totalPayment;
    public int totalCS;

    private List<GameObject> customerObjList = new List<GameObject>();

    public void Initialize(CustomerType type, Table table, int groupSize, float stayDuration, float orderInterval) {
        this.type = type;
        this.table = table;
        this.stayDuration = stayDuration;
        this.orderInterval = orderInterval;
        this.timeSpent = 0;
        this.orderTimer = 0;
        this.isEating = false;
        this.eatTimer = 0;
        this.totalPayment = 0;
        this.totalCS = 5;

        for (int i = 0; i < groupSize; i++) { // 손님을 의자에 앉히고 리스트에 추가
            GameObject customerPrefab = type.prefabs[Random.Range(0, type.prefabs.Count)];
            GameObject customerObj = Instantiate(customerPrefab, this.table.chairs[i].position + new Vector3(0.224f, 0.25f, 0f), Quaternion.identity, this.transform);
            if (i % 2 == 1) { // 홀수 의자일 경우 좌우 반전
                Vector3 scale = customerObj.transform.localScale;
                scale.x *= -1;
                customerObj.transform.localScale = scale;
                customerObj.transform.position += new Vector3(-0.448f, 0, 0);
            }
            customerObjList.Add(customerObj);
        }
        // Debug.Log($"INITIALIZED  :  {this.table.id}, {timeSpent}, {this.stayDuration}, {ordersPending}, {isEating}");
    }

    public void Update() {
        timeSpent += Time.deltaTime;
        orderTimer += Time.deltaTime;

        if (orderTimer >= orderInterval && stayDuration > timeSpent && totalCS > 0) {
            Order();
            orderTimer = 0;
        }

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
    
    public void RecieveServedOrder(Item servedItem) {
        Debug.Log($"Serve Order : {table.id} - {servedItem}");
        ordersPending--;
        isEating = true;
        eatTimer = 0;

        SetAngryEffect(false);
        if (servedItem is Recipe recipe) { // 서빙받은 게 음식이라면
            totalPayment += recipe.sellPrice;
            if (recipe.isTrash) // 쓰레기면
                decreaseCS(1);
            Debug.Log("돈 더해짐." + recipe.sellPrice);
        }
        else if (servedItem is Drink drink) { // 서빙받은 게 주류라면
            totalPayment += drink.sellPrice;
            Debug.Log("돈 더해짐." + drink.sellPrice);
        }
    }

    public void DelayOrder(string menu) { // OrderManager가 호출
        // Debug.Log($"delay Order : {table.id} - {menu}");

        decreaseCS(1);
    }

    public void CancelOrder(string menu) { // OrderManager가 호출
        // Debug.Log($"cancel Order : {table.id} - {menu}");
        ordersPending--;

        decreaseCS(2);
    }

    private void decreaseCS(int amount) {
        totalCS = Mathf.Max(0, totalCS - amount);
        SetAngryEffect(true);
    }

    public void SetAngryEffect(bool isActive) { 
        foreach (GameObject c in customerObjList) {
            if (c != null) {
                Transform effect = c.transform.Find("AngryEffect");
                if (effect != null)
                    effect.gameObject.SetActive(isActive);
            }
        }
    }

    private void Order() {
        // 랜덤 주문
        Item random;
        if (Random.Range(0,2) == 0)
            random = Managers.Prepare.Drinks[(Random.Range(0, Managers.Prepare.Drinks.Count))];
        else
            random = Managers.Prepare.Foods[(Random.Range(0, Managers.Prepare.Foods.Count))];

        Temp_OrderManager.Instance.AddOrder(table, this, random);
        ordersPending++;
        // Debug.Log($"Order : {table.id} - {random.name}");
    }

    private void Leave() {
        // Debug.Log($"Leave : {table.id}");
        // table 상태 변환 필요
        Temp_UIManager.Instance.ShowPaymentSatisfaction(table.transform.position, totalPayment, totalCS);
        table.makeDirty();
        Managers.InGame.AddValues(type.typeName, totalPayment, totalCS);
        Destroy(gameObject);
    }
}
