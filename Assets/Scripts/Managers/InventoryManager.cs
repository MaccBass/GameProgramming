using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    // ������ �κ��丮, string�� �̸�, Ingredient�� ���� Ŭ���� ����
    public Dictionary<string, Ingredient> Ingredients = new Dictionary<string, Ingredient>();
    public Dictionary<string, Recipe> Recipes = new Dictionary<string, Recipe>();
    public Dictionary<string, Drink> Drinks = new Dictionary<string, Drink>();
    public List<Tool> Tools = new List<Tool>();

    // ���� ���� �� �κ��丮 �迭 �ʱ�ȭ; ����: "NewGame" or "Load"
    public void Init(string method)
    {
        Ingredients.Clear();
        Recipes.Clear();
        Drinks.Clear();
        Tools.Clear();

        // �� ���� ���� �� �ʱ�ȭ
        if (method == "NewGame")
        {

            // �ַ�, ���� �ҷ�����
            Drink[] drinks = Resources.LoadAll<Drink>("Drinks");
            foreach (var drink in drinks)
            {
                Drinks.Add(drink.drinkName, drink);
            }
            // ����� �ҷ�����
            Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(ingredient.ingredientName, ingredient);
            }

            // ���� �ҷ�����
            Recipe[] recipes = Resources.LoadAll<Recipe>("Recipes");
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe.foodName, recipe);
            }

            Tool[] tools = Resources.LoadAll<Tool>("Tools");
            foreach (var tool in tools)
            {
                Tools.Add(tool);
            }
        }
        

        else if (method == "Load")
        {
            // ���� �ε� �� �κ��丮 �ҷ�����
        }

        else
        {
            Debug.Log("Init Error(Inventory): method = " + method);
        }
    }

}
