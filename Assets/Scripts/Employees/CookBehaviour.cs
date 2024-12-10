// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.AI;

// public class CookBehaviour : MonoBehaviour
// {
//     Order job = null;
//     bool isCooking = false;
//     Recipe holdingItem = null;
//     int targetToolIndex = -1;
//     NavMeshAgent nma;

//     float startTime;

//     // �������� ��ġ
//     public Transform[] toolLocations;
//     // ������ ��ġ
//     public Transform fridgeLocation;
//     // �⺻ ��ġ
//     public Transform idleLocation;
//     void Start()
//     {
//         nma = GetComponent<NavMeshAgent>();
//         nma.speed = 5.0f;
//     }

//     void Update()
//     {
//         if (Managers.Employee.CookOrders.Count > 0 && job == null)
//         {
//             job = Managers.Employee.CookOrders.Peek();
//         }

//         if (job == null)
//         {
//             Idle();
//         }

//         if (job != null)
//         {
//             if (job.status == OrderStatus.SERVED || job.status == OrderStatus.CANCELED)
//             {
//                 StartCoroutine(FinishCurrentJob());
//                 return;
//             }
//             // ���� �ܰ� �� �ൿ ����

//             // �����Կ� ���� �ֱ�
//             else if (holdingItem != null)
//             {
//                 MoveToFridge();
//             }

//             // �丮
//             else if (isCooking)
//             {
//                 Cook();
//             }

//             // �������� ������ �̵�
//             else if (targetToolIndex != -1) MoveToTool();

//             // �������� ��ġ ã��
//             else { GetToolLocation(); }

//         }
//     }

//     IEnumerator FinishCurrentJob()
//     {
//         while (isCooking || holdingItem != null)
//         {
//             yield return null;
//         }

//         ClearJob();
//         if (Managers.Employee.CookOrders.Count > 0)
//         {
//             job = Managers.Employee.CookOrders.Peek();
//         }
//     }
//     void GetToolLocation()
//     {
//         if (job != Managers.Employee.CookOrders.Peek()) return;

//         Recipe menu = job.menu;
//         ToolType toolType = menu.toolType;
//         var tools = Managers.Prepare.Tools.ToList();
//         for (int i = 0; i < tools.Count; i++)
//         {
//             if (tools[i].toolType == toolType)
//             {
//                 targetToolIndex = i;
//             }
//         }

//         if (targetToolIndex == -1)
//         {
//             Debug.Log("�������� ã�� ����");
//             ClearJob();
//         }
//     }
//     void MoveToTool()
//     {
//         Transform loc = toolLocations[targetToolIndex];
//         nma.SetDestination(loc.position);
//         if (nma.remainingDistance <= nma.stoppingDistance)
//         {
//             isCooking = true;
//             startTime = Time.time;
//         }
//     }
    
//     void Cook()
//     {
//         if (Time.time - startTime > job.menu.cookingTime)
//         {
//             isCooking = false;
//             holdingItem = new Recipe(job.menu);
//         }
//     }

//     void MoveToFridge()
//     {
//         Transform loc = fridgeLocation;
//         nma.SetDestination(loc.position);
//         if (nma.remainingDistance <= nma.stoppingDistance)
//         {
//             // ������� holdingItem �߰�
//             ClearJob();
//         }
//     }
//     void Idle()
//     {
//         Transform loc = idleLocation;
//         nma.SetDestination(loc.position);
//     }

//     void ClearJob()
//     {
//         holdingItem = null;
//         targetToolIndex = -1;
//         job = null;
//         if (Managers.Employee.CookOrders.Count > 0)
//         {
//             Managers.Employee.CookOrders.Dequeue();
//         }
//     }
// }
