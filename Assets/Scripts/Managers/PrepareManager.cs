using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareManager
{

    // ���� �غ� ���� �κ�
    public List<Recipe> Foods = new List<Recipe>();
    public List<Drink> Drinks = new List<Drink>();
    public List<Tool> Tools = new List<Tool>();
    public bool foodUpdated = false;
    public bool drinkUpdated = false;

    // LateUpdate�� 2�� ���Ǽ� ��¿������ �ϵ��ڵ�(���� �����ϳ� �۾����� ������.)
    public bool toolUpdated = false;
    public bool toolUpdated2 = false;

    public bool isWaiterEmployed = false;
    public bool isCookEmployed = false;
    public bool employeeUpdated = false;

    // ���� ���� �� 1ȸ�� ȣ��, (NewGame �� ���� �ʱ�ȭ, Load �� ���������� ���Ѱ� �ҷ���.)
    public void Init(string method) {

        if (method == "NewGame")
        {
            Foods.Clear();
            Drinks.Clear();
            Tools.Clear();
        }

        else if (method == "Load")
        {
            // �ε�� ���� ���� �� �ҷ���.
        }

        else
        {
            Debug.Log("InGameManager Init Error: method " + method);
        }
    }

    public void AddFood(Recipe food)
    {
        if (Foods.Contains(food))
        {
            Debug.Log("�̹� �߰��� �����Դϴ�.");
            return;
        }

        if (Foods.Count >= 10)
        {
            Debug.Log("������ 10������ �߰� �����մϴ�.");
            return;
        }

        Foods.Add(food);
        foodUpdated = true;
    }

    public void DeleteFood(Recipe food)
    {
        Foods.Remove(food);
        foodUpdated = true;
    }

    public void AddDrink(Drink drink)
    {
        if (Drinks.Contains(drink))
        {
            Debug.Log("�̹� �߰��� �ַ��Դϴ�.");
            return;
        }

        if (Drinks.Count >= 6)
        {
            Debug.Log("����� 6������ �߰� �����մϴ�.");
            return;
        }

        Drinks.Add(drink);
        drinkUpdated = true;
    }

    public void DeleteDrink(Drink drink)
    {
        Drinks.Remove(drink);
        drinkUpdated = true;
    }

    public void AddTool(Tool tool)
    {
        if (Tools.Count >= 6)
        {
            Debug.Log("������ 6������ �߰� �����մϴ�.");
            return;
        }
        if (Managers.Inventory.Tools.Contains(tool))
        {
            Tools.Add(tool);
            Managers.Inventory.Tools.Remove(tool);
        }
        else
        {
            Debug.Log("������ ������ �κ��丮�� ����.(����)");
            return;
        }
        toolUpdated = true;
        toolUpdated2 = true;
    }
    public void DeleteTool(Tool tool)
    {
        if (Tools.Contains(tool))
        {
            Tools.Remove(tool);
            Managers.Inventory.Tools.Add(tool);
        }
        else
        {
            Debug.Log("������ ������ ������ �ʾ���. (����)");
            return;
        }
        toolUpdated = true;
        toolUpdated2 = true;
    }
    public void AddWaiter()
    {
        if (isWaiterEmployed)
        {
            Debug.Log("Ȧ ���� �̹� ����");
            return;
        }
        else
        {
            isWaiterEmployed = true;
        }
        employeeUpdated = true;
    }
    public void AddCook()
    {
        if (isCookEmployed)
        {
            Debug.Log("�ֹ� ���� �̹� ����");
            return;
        }
        else
        {
            isCookEmployed = true;
        }
        employeeUpdated = true;
    }
    public void DeleteWaiter()
    {
        if (isWaiterEmployed) isWaiterEmployed = false;
        else
        {
            Debug.Log("Ȧ ������ ������ ����: ����");
            return;
        }
        employeeUpdated = true;
    }
    public void DeleteCook()
    {
        if (isCookEmployed) isCookEmployed = false;
        else
        {
            Debug.Log("�ֹ� ������ ������ ����: ����");
            return;
        }
        employeeUpdated = true;
    }
}
