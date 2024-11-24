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
}
