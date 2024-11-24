using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager
{
    // ������ �κ��丮, string�� ������(�ѱ�), Ingredient�� ���� Ŭ���� ����
    public Dictionary<string, Ingredient> IngredientsInventory = new Dictionary<string, Ingredient>();

    // ���� ���� �� �κ��丮 �迭 �ʱ�ȭ
    public void InitInventory(string method)
    {
        IngredientsInventory.Clear();

        // �� ���� ���� �� �ʱ�ȭ
        if (method == "NewGame")
        {
            Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
            foreach(var ingredient in ingredients)
            {
                IngredientsInventory.Add(ingredient.name, ingredient);
            }
        }
        

        else if (method == "Load")
        {
            // ���� �ε� �� �κ��丮 �ҷ�����
        }

        else
        {
            Debug.Log("Init Error(Inventory): method = " + method);
        }
    }

    // ����� ���� ������ ��ȯ�ϴ� �Լ�
    public int GetIngredientQuantity(string name)
    {
        if (IngredientsInventory.TryGetValue(name, out Ingredient ingredient))
        {
            return ingredient.quantity;
        }
        else
        {
            return 0;
        }
    }
}
