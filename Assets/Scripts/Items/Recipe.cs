using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFood", menuName = "Items/Recipes")]
public class Recipe : Item
{
    public ToolType toolType;
    public int purchasePrice;
    public int sellPrice;
    public int cookingTime;
    public bool isObtained;
    public string[] ingredients;

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
