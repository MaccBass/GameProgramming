using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    // ������ �κ��丮, string�� �̸�, Ingredient�� ���� Ŭ���� ����
    public Dictionary<string, Ingredient> Ingredients = new Dictionary<string, Ingredient>();
    public Dictionary<string, Recipe> Recipes = new Dictionary<string, Recipe>();

    // ���� ���� �� �κ��丮 �迭 �ʱ�ȭ; ����: "NewGame" or "Load"
    public void Init(string method)
    {
        Ingredients.Clear();
        Recipes.Clear();

        // �� ���� ���� �� �ʱ�ȭ
        if (method == "NewGame")
        {
            // ����� �ҷ�����
            Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(ingredient.name, ingredient);
            }

            // ���� �ҷ�����
            Recipe[] recipes = Resources.LoadAll<Recipe>("Recipes");
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe.name, recipe);
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
