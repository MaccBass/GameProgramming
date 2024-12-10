using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CookBehaviour : MonoBehaviour
{
    Order job = null;
    float startTime;
    bool isCooking = false;
    Recipe holdingItem = null;

    // 조리도구 위치
    public Transform[] toolLocations;
    // 보관함 위치
    public Transform fridgeLocation;
    // 기본 위치
    public Transform idleLocation;
    // 음식 냉장고
    public Fridge fridge;

    private Seeker seeker;
    private Path path;
    private float threshold = 0.1f;
    int targetToolIndex = -1;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        AstarPath.active.logPathResults = Pathfinding.PathLog.None;
        job = null;
    }

    void Update()
    {
        if (Managers.Employee.CookOrders.Count > 0 && job == null)
        {
            job = Managers.Employee.CookOrders.Peek();
            Debug.Log("주문 큐에서 " + job.orderItem.itemName + " 확인");
        }
        if (job == null)
        {
            Idle();
        }
        if (job != null)
        {
            if (job.status == OrderStatus.SERVED || job.status == OrderStatus.CANCELED)
            {
                StartCoroutine(FinishCurrentJob());
                return;
            }
            // 현재 단계 별 행동 정의
            // 보관함에 음식 넣기
            else if (holdingItem != null)
            {
                MoveToFridge();
            }
            // 요리
            else if (isCooking)
            {
                Cook();
            }
            // 조리도구 앞으로 이동
            else if (targetToolIndex != -1)
            {
                Debug.Log(targetToolIndex.ToString() + "번 조리기구로 이동");
                MoveToTool();
            }
            // 조리도구 위치 찾기
            else { GetToolLocation(); }
        }

    }
    IEnumerator FinishCurrentJob()
    {
        while (isCooking || holdingItem != null)
        {
            yield return null;
        }
        ClearJob();
        if (Managers.Employee.CookOrders.Count > 0)
        {
            job = Managers.Employee.CookOrders.Peek();
        }
    }
    void GetToolLocation()
    {
        if (job != Managers.Employee.CookOrders.Peek()) 
        {
            Debug.Log("job과 peek가 다름");
            job = null;
            Managers.Employee.CookOrders.Dequeue();
            return;
        }
        if (job.orderItem is not Recipe)
        {
            Debug.Log("주문내역이 음식이 아니므로 폐기");
            job = null;
            Managers.Employee.CookOrders.Dequeue();
            return;
        }
        Recipe menu = (Recipe)job.orderItem;
        ToolType toolType = menu.toolType;
        var tools = Managers.Prepare.Tools.ToList();
        for (int i = 0; i < tools.Count; i++)
        {
            if (tools[i].toolType == toolType)
            {
                targetToolIndex = i;
            }
        }
        if (targetToolIndex == -1)
        {
            Debug.Log("조리도구 찾지 못함");
            ClearJob();
        }
    }
    void MoveToTool()
    {
        if (targetToolIndex < 0)
        {
            Debug.LogError("targetToolIndex가 잘못됨");
            return;
        }
        Transform loc = toolLocations[targetToolIndex];
        seeker.StartPath(transform.position, loc.position);
        if (Vector3.Distance(transform.position, loc.position) < threshold)
        {
            path = null;
            isCooking = true;
            startTime = Time.time;
            Debug.Log("조리기구 위치 도달");
        }
    }

    void Cook()
    {
        Debug.Log("조리중..");
        if (job.orderItem is Recipe food)
        {
            if (Time.time - startTime > food.cookingTime)
            {
                isCooking = false;
                holdingItem = new Recipe(food);
            }
        }
        else
        {
            Debug.LogError("알바생 Cook()에서 문제 발생: orderItem이 Recipe 타입이 아님.");
        }
    }
    void MoveToFridge()
    {
        Debug.Log("냉장고로 이동중");
        Transform loc = fridgeLocation;
        seeker.StartPath(transform.position, loc.position);
        if (Vector3.Distance(transform.position, loc.position) < threshold)
        {
            Debug.Log("냉장고에 도달");
            path = null;
            fridge.AddItem(holdingItem);
            ClearJob();
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
        Debug.Log("Job이 없으므로 제자리로 돌아감.");
    }
    void ClearJob()
    {
        holdingItem = null;
        targetToolIndex = -1;
        job = null;
        if (Managers.Employee.CookOrders.Count > 0)
        {
            Managers.Employee.CookOrders.Dequeue();
        }
    }
}