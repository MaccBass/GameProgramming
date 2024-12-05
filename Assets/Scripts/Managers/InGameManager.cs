using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager
{
    public List<Recipe> Foods = new List<Recipe>();
    public List<Drink> Drinks = new List<Drink>();
    public List<Tool> Tools = new List<Tool>();
    public bool foodUpdated = false;
    public bool drinkUpdated = false;

    // ���� ���� �� 1ȸ�� ȣ��, (NewGame �� ���� �ʱ�ȭ, Load �� ���������� ���Ѱ� �ҷ���.)
    public void Init(string method) {

        if (method == "NewGame")
        {
            Foods.Clear();
            Drinks.Clear();
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
}
