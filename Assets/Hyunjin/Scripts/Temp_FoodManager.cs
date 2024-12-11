/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지워야됨

public class Temp_FoodManager : MonoBehaviour
{
    public static Temp_FoodManager Instance { get; private set; }

    // 모든 Food ScriptableObject를 저장할 리스트
    public List<Recipe> foodList = new List<Recipe>();
    public List<Drink> drinkList = new List<Drink>();
    public List<Ingredient> ingredientList = new List<Ingredient>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // "Recipe" 폴더에서 모든 ScriptableObject를 로드
        Recipe[] foods = Resources.LoadAll<Recipe>("Recipes");
        foreach(Recipe f in foods) {
            Managers.Prepare.Foods.Add(f);
        }

        Drink[] drinks = Resources.LoadAll<Drink>("Drinks");
        foreach(Drink d in drinks) {
            Managers.Prepare.Drinks.Add(d);
        }

        Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
        foreach(Ingredient i in ingredients) {
            Managers.Inventory.Ingredients.Add(i.itemName, i);
        }
    }

}

*/