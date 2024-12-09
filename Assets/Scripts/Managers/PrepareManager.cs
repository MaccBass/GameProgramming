using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareManager
{

    // 가게 준비 관련 부분
    public List<Recipe> Foods = new List<Recipe>();
    public List<Drink> Drinks = new List<Drink>();
    public List<Tool> Tools = new List<Tool>();
    public bool foodUpdated = false;
    public bool drinkUpdated = false;

    // LateUpdate가 2번 사용되서 어쩔수없이 하드코딩(수정 가능하나 작업량이 많아짐.)
    public bool toolUpdated = false;
    public bool toolUpdated2 = false;

    public bool isWaiterEmployed = false;
    public bool isCookEmployed = false;
    public bool employeeUpdated = false;

    // 게임 시작 시 1회만 호출, (NewGame 시 완전 초기화, Load 시 마지막으로 편성한거 불러옴.)
    public void Init(string method) {

        if (method == "NewGame")
        {
            Foods.Clear();
            Drinks.Clear();
            Tools.Clear();
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

    public void AddTool(Tool tool)
    {
        if (Tools.Count >= 6)
        {
            Debug.Log("도구는 6개까지 추가 가능합니다.");
            return;
        }
        if (Managers.Inventory.Tools.Contains(tool))
        {
            Tools.Add(tool);
            Managers.Inventory.Tools.Remove(tool);
        }
        else
        {
            Debug.Log("선택한 도구가 인벤토리에 없음.(오류)");
            return;
        }
        toolUpdated = true;
        toolUpdated2 = true;
    }
    public void DeleteTool(Tool tool)
    {
        if (Tools.Contains(tool))
        {
            Tools.Remove(tool);
            Managers.Inventory.Tools.Add(tool);
        }
        else
        {
            Debug.Log("선택한 도구가 편성되지 않았음. (오류)");
            return;
        }
        toolUpdated = true;
        toolUpdated2 = true;
    }
    public void AddWaiter()
    {
        if (isWaiterEmployed)
        {
            Debug.Log("홀 직원 이미 고용됨");
            return;
        }
        else
        {
            isWaiterEmployed = true;
        }
        employeeUpdated = true;
    }
    public void AddCook()
    {
        if (isCookEmployed)
        {
            Debug.Log("주방 직원 이미 고용됨");
            return;
        }
        else
        {
            isCookEmployed = true;
        }
        employeeUpdated = true;
    }
    public void DeleteWaiter()
    {
        if (isWaiterEmployed) isWaiterEmployed = false;
        else
        {
            Debug.Log("홀 직원이 편성되지 않음: 오류");
            return;
        }
        employeeUpdated = true;
    }
    public void DeleteCook()
    {
        if (isCookEmployed) isCookEmployed = false;
        else
        {
            Debug.Log("주방 직원이 편성되지 않음: 오류");
            return;
        }
        employeeUpdated = true;
    }
}
