using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Items/Ingredient")]
public class Ingredient : Item
{
    public IngredientType ingredientType;
    public int quantity;
}
