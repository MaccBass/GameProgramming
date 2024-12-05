using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager
{
    public List<Recipe> Foods = new List<Recipe>();
    public List<Drink> Drinks = new List<Drink>();
    public List<Tool> Tools = new List<Tool>();
    public bool foodUpdated = false;
    public bool drinkUpdated = false;

    // 게임 시작 시 1회만 호출, (NewGame 시 완전 초기화, Load 시 마지막으로 편성한거 불러옴.)
    public void Init(string method) {

        if (method == "NewGame")
        {
            Foods.Clear();
            Drinks.Clear();
        }

        else if (method == "Load")
        {
            // 로드시 기존 편성한 거 불러옴.
        }
        
        else
        {
            Debug.Log("InGameManager Init Error: method " + method);
        }
    }

    public void AddFood(Recipe food)
    {
        if (Foods.Contains(food))
        {
            Debug.Log("이미 추가된 음식입니다.");
            return;
        }

        if (Foods.Count >= 10)
        {
            Debug.Log("음식은 10개까지 추가 가능합니다.");
            return;
        }

        Foods.Add(food);
        foodUpdated = true;
    }

    public void DeleteFood(Recipe food)
    {
        Foods.Remove(food);
        foodUpdated = true;
    }

    public void AddDrink(Drink drink)
    {
        if (Drinks.Contains(drink))
        {
            Debug.Log("이미 추가된 주류입니다.");
            return;
        }

        if (Drinks.Count >= 6)
        {
            Debug.Log("음료는 6개까지 추가 가능합니다.");
            return;
        }

        Drinks.Add(drink);
        drinkUpdated = true;
    }

    public void DeleteDrink(Drink drink)
    {
        Drinks.Remove(drink);
        drinkUpdated = true;
    }
}
