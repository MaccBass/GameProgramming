using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<Table> tableList; // 테이블 리스트
    public List<CustomerType> customerTypeList; // 고객 타입 정보

    public float minSpawnInterval = 3f;
    public float maxSpawnInterval = 5f;    

    void Start() {
        tableList = new List<Table>(FindObjectsOfType<Table>());
        // foreach(Recipe f in Managers.InGame.Foods) {
        //     Debug.Log(f.name);
        // }
        StartCoroutine(SpawnCustomers());
    }

    private IEnumerator SpawnCustomers() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            AssignRandomCustomerToTable();
        }
    }

    // 착석 가능한 테이블 찾고 랜덤 손님 배정
    private void AssignRandomCustomerToTable() {
        List<Table> availableTables = tableList.FindAll(t => t.status == TableStatus.EMPTY);
        if (availableTables.Count <= 0) return;

        Table chosenTable = availableTables[Random.Range(0, availableTables.Count)];
        CustomerType chosenType = customerTypeList[Random.Range(0, customerTypeList.Count)];
        int groupSize = chosenType.isEvent ? 1 : Random.Range(1, chosenTable.chairNum + 1);
        float stayDuration = Random.Range(chosenType.MinStayDuration, chosenType.MaxStayDuration);
        float orderInterval = Random.Range(chosenType.MinOrderInterval, chosenType.MaxOrderInterval);

        // 고객 그룹 관리자 객체 생성 및 초기화
        GameObject customerGroupObj = new GameObject("CustomerGroup");
        customerGroupObj.transform.SetParent(chosenTable.transform);
        Customer customerGroup = customerGroupObj.AddComponent<Customer>();
        customerGroup.Initialize(chosenType, chosenTable, groupSize, stayDuration, orderInterval);

        chosenTable.status = TableStatus.OCCUPIED;
    }
}
