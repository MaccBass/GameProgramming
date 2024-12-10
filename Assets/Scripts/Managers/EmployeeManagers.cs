using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager
{
    /* 주방알바 작동원리
     * 큐 top에 있는 Order의 주문을 처리함.
     * 만약 큐 top에 있는 주문의 음식이 보관함에 있다면,
     * 그 즉시 큐를 pop하고 다음 top의 주문을 처리하러 감.
     * 
     * 큐 top에 있는 주문내역 내의 음식을 보고,
     * 음식의 ToolType을 참고한 다음,
     * PrepareManager 내의 Tools 리스트에서 가장 왼쪽에 있는 Tool 앞으로 가서 조리 시작
     * cookingTime 시간동안 앞에 서있는다.(다른 동작 x)
     * 요리가 끝나면 그 요리를 집어서 보관함(Fridge?)에 넣음.
     */
    // 주방알바가 음식을 만들 때 사용할 큐
    public Queue<Order> CookOrders = new Queue<Order>();

    /* 홀 알바 작동원리
     * 큐 top에 있는 Order의 주문을 처리함.
     * 만약 서빙하러 이동 중 큐 top에 있는 주문이 처리가 된다면,
     * 해당 주문을 pop하고 다음 top에 있는 주문을 처리하러 감.
     * 
     * 들고있는 중 완료가 되었을 때: 해당 음식을 보관함에 넣고 다음 주문을 처리하러 감.
     * 들고있지 않을 때 완료가 되었을 때: 바로 다음 주문 처리하러 감.
     * 
     * 큐 top에 있는 Order 내의 음식or주류를 보고,
     * 주류의 경우: 냉장고 앞으로 이동한 다음 해당 주류를 들고 손님한테 감.
     * 음식의 경우: 냉장고 내에 해당 음식이 있으면 들고 손님한테 감.
     * 냉장고 내에 없으면 해당 음식이 보관함에 들어올 때까지 기다림.
     */
    public Queue<Order> WaiterOrders = new Queue<Order>();


    public void Init()
    {
        CookOrders.Clear();
        WaiterOrders.Clear();
    }
    public void AddOrder(Order order)
    {
        if (Managers.Prepare.isCookEmployed)
        {
            CookOrders.Enqueue(order);
            Debug.Log("주방알바 주문에 " + order.orderItem.itemName + "들어감.");
        }
        if (Managers.Prepare.isWaiterEmployed)
        {
            WaiterOrders.Enqueue(order);
            Debug.Log("홀알바 주문에 " + order.orderItem.itemName + "들어감.");

        }
    }
}
