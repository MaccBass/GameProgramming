using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager
{
    public List<Recipe> Foods = new List<Recipe>();
    public bool foodUpdated = false;

    // 게임 시작 시 1회만 호출, (NewGame 시 완전 초기화, Load 시 마지막으로 편성한거 불러옴.)
    public void Init(string method) {

        if (method == "NewGame")
        {
            Foods.Clear();
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

    public void addFood(Recipe food)
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

    public void deleteFood(Recipe food)
    {
        Foods.Remove(food);
        foodUpdated = true;
    }
}
