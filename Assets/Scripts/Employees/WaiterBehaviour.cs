using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WaiterBehaviour : MonoBehaviour {
    
    private enum FridgeType
    {
        NULL, FOOD, DRINK
    }
    Order job = null;
    Item holdingItem = null;
    FridgeType targetFridge = FridgeType.NULL;

    // �������� ��ġ
    public Transform[] tableLocations;
    // ������ ��ġ
    public Transform fridgeLocation;
    // �ַ� ����� ��ġ
    public Transform drinkLocation;
    // �⺻ ��ġ
    public Transform idleLocation;
    // ���� �����
    public Fridge fridge;
    public DrinkFridge drink;

    private Seeker seeker;
    private Path path;
    private float threshold = 0.05f;
    int targetTableIndex = -1;
    void Start()
    {
        if (!Managers.Prepare.isWaiterEmployed)
        {
            gameObject.SetActive(false);
        }
        seeker = GetComponent<Seeker>();
        AstarPath.active.logPathResults = Pathfinding.PathLog.None;
        job = null;
    }

    void Update()
    {
        if (Managers.Employee.WaiterOrders.Count > 0 && job == null)
        {
            job = Managers.Employee.WaiterOrders.Peek();
            Debug.Log("�ֹ� ť���� " + job.orderItem.itemName + " Ȯ��");
        }
        if (job == null)
        {
            Idle();
        }
        // job�� ������ ��
        if (job != null)
        {
            if (job.status == OrderStatus.SERVED || job.status == OrderStatus.CANCELED)
            {
                ClearJob();
                return;
            }
            else if (holdingItem != null)
            {
                MoveToTable();
            }
            else if (targetFridge != FridgeType.NULL)
            {
                MoveToFridge();
            }
            else
            {
                GetFridgeTarget();
            }
        }
    }
    void MoveToTable()
    {
        targetTableIndex = job.table.id - 1;
        Transform loc = tableLocations[targetTableIndex];
        seeker.StartPath(transform.position, loc.position);
        if (Vector3.Distance(transform.position, loc.position) < threshold)
        {
            path = null;
            holdingItem = null;
            ClearJob();
        }
    }
    void MoveToFridge()
    {
        Transform loc = transform;
        if (targetFridge == FridgeType.NULL)
        {
            Debug.LogError("FridgeType�� NULL��.");
            return;
        }
        if (targetFridge == FridgeType.FOOD)
        {
            loc = fridgeLocation;
            seeker.StartPath(transform.position, loc.position);
            if (Vector3.Distance(transform.position, loc.position) < threshold)
            {
                path = null;
                // ������� ������ ������
                holdingItem = new Recipe((Recipe)job.orderItem);
                fridge.FridgeRecipe.Remove((Recipe)holdingItem);
            }
        }
        else if (targetFridge == FridgeType.DRINK)
        {
            loc = drinkLocation;
            seeker.StartPath(transform.position, loc.position);
            if (Vector3.Distance(transform.position, loc.position) < threshold)
            {
                path = null;
                Drink drink = (Drink)job.orderItem;
                holdingItem = Managers.Prepare.Drinks.Find(d => d.itemName == drink.itemName);
                ((Drink)holdingItem).quantity--;
            }
        }
    }

    void GetFridgeTarget()
    {
        if (job.orderItem is Recipe food)
        {
            targetFridge = FridgeType.FOOD;
        }
        else if (job.orderItem is Drink drink)
        {
            targetFridge = FridgeType.DRINK;
        }
    }

    void Idle()
    {
        Transform loc = idleLocation;
        seeker.StartPath(transform.position, loc.position);
        if (Vector3.Distance(transform.position, loc.position) < threshold / 10)
        {
            path = null;
        }
        Debug.Log("Job�� �����Ƿ� ���ڸ��� ���ư�.");
    }
    void ClearJob()
    {
        holdingItem = null;
        targetTableIndex = -1;
        targetFridge = FridgeType.NULL;
        job = null;
        if (Managers.Employee.WaiterOrders.Count > 0)
        {
            Managers.Employee.WaiterOrders.Dequeue();
        }
    }
}
