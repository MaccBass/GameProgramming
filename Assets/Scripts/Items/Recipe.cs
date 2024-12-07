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

    // 갖고있는 재료로 요리 가능한 갯수, 모든 요리는 재료를 1개씩만 사용함.
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
