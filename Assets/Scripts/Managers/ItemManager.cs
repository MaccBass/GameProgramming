using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager
{
    // 아이템 인벤토리, string은 식재료명(한글), Ingredient는 실제 클래스 변수
    public Dictionary<string, Ingredient> IngredientsInventory = new Dictionary<string, Ingredient>();

    // 게임 시작 시 인벤토리 배열 초기화
    public void InitInventory(string method)
    {
        IngredientsInventory.Clear();

        // 새 게임 시작 시 초기화
        if (method == "NewGame")
        {
            Ingredient[] ingredients = Resources.LoadAll<Ingredient>("Ingredients");
            foreach(var ingredient in ingredients)
            {
                IngredientsInventory.Add(ingredient.name, ingredient);
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

    // 식재료 현재 개수를 반환하는 함수
    public int GetIngredientQuantity(string name)
    {
        if (IngredientsInventory.TryGetValue(name, out Ingredient ingredient))
        {
            return ingredient.quantity;
        }
        else
        {
            return 0;
        }
    }
}
