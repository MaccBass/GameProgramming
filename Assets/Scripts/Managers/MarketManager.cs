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

    public bool cartUpdated = false;

    public void Init(string method)
    {
        if (method == "NewGame")
        {
            Ingredients.Clear();
            Drinks.Clear();
            Recipes.Clear();
            Tools.Clear();

            Cart.Clear();

            // 주류, 음료 불러오기
            Drink[] drinks = Resources.LoadAll<Drink>("Drinks");
            foreach (var drink in drinks)
            {
                Drinks.Add(drink);
            }
            // 식재료 불러오기
            Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(ingredient);
            }

            // 음식 불러오기
            Recipe[] recipes = Resources.LoadAll<Recipe>("Recipes");
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe);
            }

            Tool[] tools = Resources.LoadAll<Tool>("Tools");
            foreach (var tool in tools)
            {
                Tools.Add(tool);
            }
        }
    }

    public void AddCart(Item item)
    {
        if (Cart.ContainsKey(item))
        {
            Cart[item]++;
        }
        else
        {
            Cart.Add(item, 1);
        }

        cartUpdated = true;
    }

    public void BuyCart()
    {
        foreach (var cart in Cart)
        {
            Item item = cart.Key;
            int quantity = cart.Value;

            if (item is Ingredient ingredient)
            {
                Managers.Inventory.Ingredients[ingredient.itemName].quantity += quantity;
            }
            else if (item is Recipe recipe)
            {
                Managers.Inventory.Recipes[recipe.itemName].isObtained = true;
            }
            else if (item is Drink drink)
            {
                Managers.Inventory.Drinks[drink.itemName].quantity += quantity;
            }
            else if (item is Tool tool)
            {
                Managers.Inventory.Tools.Add(tool);
            }
        }

        Cart.Clear();
    }
}
