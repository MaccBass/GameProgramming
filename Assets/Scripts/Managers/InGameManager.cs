using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager
{
    public List<Recipe> Foods = new List<Recipe>();
    public bool foodUpdated = false;

    // ���� ���� �� 1ȸ�� ȣ��, (NewGame �� ���� �ʱ�ȭ, Load �� ���������� ���Ѱ� �ҷ���.)
    public void Init(string method) {

        if (method == "NewGame")
        {
            Foods.Clear();
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

    public void addFood(Recipe food)
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

    public void deleteFood(Recipe food)
    {
        Foods.Remove(food);
        foodUpdated = true;
    }
}
