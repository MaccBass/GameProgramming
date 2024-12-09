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

    public int totalPrice;
    public bool cartUpdated = false;

    public void Init(string method)
    {
        totalPrice = 0;
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
            if (item is Recipe recipe)
            {
                return;
            }
            else
            {
                Cart[item]++;
            }
        }
        else
        {
            Cart.Add(item, 1);
        }
        totalPrice += item.purchasePrice;

        Debug.Log("Cart에 " + item.itemName + " 추가됨.");
        cartUpdated = true;
    }

    public void DeleteCart(Item item)
    {
        if (Cart[item] == 1)
        {
            Cart.Remove(item);
        }
        else
        {
            Cart[item]--;
        }
        totalPrice -= item.purchasePrice;

        Debug.Log("Cart에서 " + item.itemName + " 1개 제거됨.");
        cartUpdated = true;
    }

    public void BuyCart()
    {
        if (Managers.Status.totalMoney < totalPrice)
        {
            Debug.Log("소지금 부족");
            return;
        }
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
                for (int i = 0; i < quantity; i++)
                {
                    Managers.Inventory.Tools.Add(tool);
                }
            }
        }

        Managers.InGame.shoppingCost += totalPrice;
        Managers.Status.totalMoney -= totalPrice;
        totalPrice = 0;
        cartUpdated = true;
        Cart.Clear();
    }
}
