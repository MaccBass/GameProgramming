using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFood", menuName = "Items/Recipes")]
public class Recipe : Item
{
    public ToolType toolType;
    public int sellPrice;
    public int cookingTime;
    public bool isObtained;
    public string[] ingredients;
    public bool isTrash;

    public Recipe(Recipe origin)
    {
        icon = origin.icon;
        itemName = origin.itemName;
        purchasePrice = origin.purchasePrice;
        toolType = origin.toolType;
        sellPrice = origin.sellPrice;
        cookingTime = origin.cookingTime;
        isObtained = origin.isObtained;
        ingredients = origin.ingredients;
        isTrash = origin.isTrash;
    }

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
