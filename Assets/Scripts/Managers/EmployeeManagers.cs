using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager
{
    /* �ֹ�˹� �۵�����
     * ť top�� �ִ� Order�� �ֹ��� ó����.
     * ���� ť top�� �ִ� �ֹ��� ������ �����Կ� �ִٸ�,
     * �� ��� ť�� pop�ϰ� ���� top�� �ֹ��� ó���Ϸ� ��.
     * 
     * ť top�� �ִ� �ֹ����� ���� ������ ����,
     * ������ ToolType�� ������ ����,
     * PrepareManager ���� Tools ����Ʈ���� ���� ���ʿ� �ִ� Tool ������ ���� ���� ����
     * cookingTime �ð����� �տ� ���ִ´�.(�ٸ� ���� x)
     * �丮�� ������ �� �丮�� ��� ������(Fridge?)�� ����.
     */
    // �ֹ�˹ٰ� ������ ���� �� ����� ť
    public Queue<Order> CookOrders = new Queue<Order>();

    /* Ȧ �˹� �۵�����
     * ť top�� �ִ� Order�� �ֹ��� ó����.
     * ���� �����Ϸ� �̵� �� ť top�� �ִ� �ֹ��� ó���� �ȴٸ�,
     * �ش� �ֹ��� pop�ϰ� ���� top�� �ִ� �ֹ��� ó���Ϸ� ��.
     * 
     * ����ִ� �� �Ϸᰡ �Ǿ��� ��: �ش� ������ �����Կ� �ְ� ���� �ֹ��� ó���Ϸ� ��.
     * ������� ���� �� �Ϸᰡ �Ǿ��� ��: �ٷ� ���� �ֹ� ó���Ϸ� ��.
     * 
     * ť top�� �ִ� Order ���� ����or�ַ��� ����,
     * �ַ��� ���: ����� ������ �̵��� ���� �ش� �ַ��� ��� �մ����� ��.
     * ������ ���: ����� ���� �ش� ������ ������ ��� �մ����� ��.
     * ����� ���� ������ �ش� ������ �����Կ� ���� ������ ��ٸ�.
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
            Debug.Log("�ֹ�˹� �ֹ��� " + order.orderItem.itemName + "��.");
        }
        if (Managers.Prepare.isWaiterEmployed)
        {
            WaiterOrders.Enqueue(order);
            Debug.Log("Ȧ�˹� �ֹ��� " + order.orderItem.itemName + "��.");

        }
    }
}
