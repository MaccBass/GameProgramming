using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CookBehaviour : MonoBehaviour
{
    Order job = null;
    bool isCooking = false;
    Recipe holdingItem = null;
    int targetToolIndex = -1;
    NavMeshAgent nma;

    float startTime;

    // 조리도구 위치
    public Transform[] toolLocations;
    // 보관함 위치
    public Transform fridgeLocation;
    // 기본 위치
    public Transform idleLocation;
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Managers.Employee.CookOrders.Count > 0 && job == null)
        {
            job = Managers.Employee.CookOrders.Peek();
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
            else if (targetToolIndex != -1) MoveToTool();

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
        if (job != Managers.Employee.CookOrders.Peek()) return;

        Recipe menu = job.menu;
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
        Transform loc = toolLocations[targetToolIndex];
        nma.SetDestination(loc.position);
        if (nma.remainingDistance <= nma.stoppingDistance)
        {
            isCooking = true;
            startTime = Time.time;
        }
    }
    
    void Cook()
    {
        if (Time.time - startTime > job.menu.cookingTime)
        {
            isCooking = false;
            holdingItem = new Recipe(job.menu);
        }
    }

    void MoveToFridge()
    {
        Transform loc = fridgeLocation;
        nma.SetDestination(loc.position);
        if (nma.remainingDistance <= nma.stoppingDistance)
        {
            // 냉장고에 holdingItem 추가
            ClearJob();
        }
    }
    void Idle()
    {
        Transform loc = idleLocation;
        nma.SetDestination(loc.position);
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
