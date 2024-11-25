using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDrink", menuName = "Items/Drinks")]
public class Drink : ScriptableObject
{
    public string drinkName;
    public int purchasePrice;
    public int sellPrice;
    public int quantity;
    public Sprite icon;
}
