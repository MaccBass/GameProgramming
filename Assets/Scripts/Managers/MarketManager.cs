using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarketManager
{
    public List<Ingredient> Ingredients = new List<Ingredient>();
    public List<Drink> Drinks = new List<Drink>();
    public List<Recipe> Recipes = new List<Recipe>();
    public List<Tool> Tools = new List<Tool>();

    public Dictionary<Item, int> Cart = new Dictionary<Item, int>();

    public void Init()
    {

    }

    public void AddCart(Item item)
    {
        if (item is Tool)
        {
            if (Cart.ContainsKey(item))
            {

            }
        }
        else
        {
            
        }
    }
}
