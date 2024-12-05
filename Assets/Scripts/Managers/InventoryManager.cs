using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    // 아이템 인벤토리, string은 이름, Ingredient는 실제 클래스 변수
    public Dictionary<string, Ingredient> Ingredients = new Dictionary<string, Ingredient>();
    public Dictionary<string, Recipe> Recipes = new Dictionary<string, Recipe>();
    public Dictionary<string, Drink> Drinks = new Dictionary<string, Drink>();
    public List<Tool> Tools = new List<Tool>();

    // 게임 시작 시 인벤토리 배열 초기화; 인자: "NewGame" or "Load"
    public void Init(string method)
    {
        Ingredients.Clear();
        Recipes.Clear();
        Drinks.Clear();
        Tools.Clear();

        // 새 게임 시작 시 초기화
        if (method == "NewGame")
        {

            // 주류, 음료 불러오기
            Drink[] drinks = Resources.LoadAll<Drink>("Drinks");
            foreach (var drink in drinks)
            {
                Drinks.Add(drink.drinkName, drink);
            }
            // 식재료 불러오기
            Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(ingredient.ingredientName, ingredient);
            }

            // 음식 불러오기
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
            // 게임 로드 시 인벤토리 불러오기
        }

        else
        {
            Debug.Log("Init Error(Inventory): method = " + method);
        }
    }

}
