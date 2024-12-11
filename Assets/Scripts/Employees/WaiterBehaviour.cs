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
    private float threshold = 0.1f;
    int targetTableIndex = -1;

    Animator animator;

    void Start()
    {
        if (!Managers.Prepare.isWaiterEmployed)
        {
            gameObject.SetActive(false);
        }
        seeker = GetComponent<Seeker>();
        AstarPath.active.logPathResults = Pathfinding.PathLog.None;
        animator = GetComponent<Animator>();
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

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath() {
        Vector3 lastPosition = transform.position;

        foreach (Vector3 point in path.vectorPath) {
            while (Vector3.Distance(transform.position, point) > threshold) {
                Vector3 moveDirection = (point - transform.position).normalized;
                Vector3 newPosition = transform.position + moveDirection * 0.1f;
                transform.position = newPosition;
                AnimateMove(moveDirection); // 이동 방향에 따라 애니메이션 적용
                yield return null;
            }
        }
        animator.SetFloat("Move X", 0); // 이동 정지 시 애니메이션 정지
        animator.SetFloat("Move Y", 0);
    }

    void AnimateMove(Vector3 direction) {
        animator.SetFloat("Move X", direction.x);
        animator.SetFloat("Move Y", direction.y);
    }

    void MoveToTable()
    {
        targetTableIndex = job.table.id - 1;
        Transform loc = tableLocations[targetTableIndex];
        seeker.StartPath(transform.position, loc.position, OnPathComplete);
        if (Vector3.Distance(transform.position, loc.position) < threshold)
        {
            path = null;
            Temp_OrderManager.Instance.ServeOrder(holdingItem, job.customer);
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
            Recipe food = (Recipe)job.orderItem;
            if (fridge.FridgeRecipe.Find(f => f.itemName == food.itemName) == null)
            {
                return;
            }
            if (food.CookCount() <= 0)
            {
                Debug.Log(food.itemName + "�� ���̻� ���� �� ����.");
                ClearJob();
            }
            loc = fridgeLocation;
            seeker.StartPath(transform.position, loc.position, OnPathComplete);
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
            Drink drink = (Drink)job.orderItem;
            if (Managers.Prepare.Drinks.Find(d => d.itemName == drink.itemName) == null)
            {
                Debug.Log(drink.itemName + " ����� ����.");
                ClearJob();
            }
            loc = drinkLocation;
            seeker.StartPath(transform.position, loc.position, OnPathComplete);
            if (Vector3.Distance(transform.position, loc.position) < threshold)
            {
                path = null;
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
        seeker.StartPath(transform.position, loc.position, OnPathComplete);
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
