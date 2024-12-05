using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
public class FoodUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject menuObj;

    void OnEnable()
    {
        // 기존 UI 제거
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // 버튼 생성
        foreach (var recipe in Managers.Inventory.Recipes.Values.ToList())
        {
            if (!recipe.isObtained) continue;

            GameObject obj = Instantiate(menuObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // 버튼 이미지
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = recipe.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(recipe));
            button.onClick.AddListener(() => OnRightClick(recipe));

            // 수량 표시
            Text quantity = obj.GetComponentInChildren<Text>();
            quantity.text = recipe.CookCount().ToString();
        }
    }

    void OnLeftClick(Recipe recipe)
    {
        Managers.InGame.AddFood(recipe);
    }

    void OnRightClick(Recipe recipe)
    {
        // 우클릭시
        Debug.Log("메뉴 " + recipe.itemName + " 클릭됨.");
    }
}
