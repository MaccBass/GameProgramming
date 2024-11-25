using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Items/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public IngredientType ingredientType;
    public int price;
    public int quantity;
    public Sprite icon;
}
