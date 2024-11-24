using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFood", menuName = "Items/Recipes")]
public class Recipe : ScriptableObject
{
    public string foodName;
    public ToolType toolType;
    public int price;
    public int cookingTime;
    public bool isObtained;
    public string[] ingredients;
    public Sprite icon;

    // �����ִ� ���� �丮 ������ ����, ��� �丮�� ��Ḧ 1������ �����.
    public int CookCount()
    {
        int maxQuantity = 9999;
        foreach (string ingredient in ingredients)
        {
            int quantity = Managers.Inventory.Ingredients[ingredient].quantity;
            maxQuantity = Mathf.Min(maxQuantity, quantity);
        }

        return maxQuantity;
    }
}
