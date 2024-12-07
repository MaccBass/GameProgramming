using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
public class IngredientUI : MonoBehaviour
{
    public List<Transform> posBases;
    public GameObject ingredientObj;

    void OnEnable()
    {
        // 기존 UI 제거
        foreach (Transform posBase in posBases)
        {
            foreach (Transform child in posBase)
            {
                Destroy(child.gameObject);
            }
        }

        // 버튼 생성
        foreach (var ingredient in Managers.Inventory.Ingredients.Values.ToList())
        {
            if (ingredient.quantity == 0) continue;

            // 세로열 위치
            Transform posBase = posBases[(int)ingredient.ingredientType];
            GameObject obj = Instantiate(ingredientObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // 버튼 이미지
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = ingredient.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(ingredient));
            button.onClick.AddListener(() => OnRightClick(ingredient));

            // 수량 표시
            Text quantity = obj.GetComponentInChildren<Text>();
            quantity.text = ingredient.quantity.ToString();
        }
    }

    void OnLeftClick(Ingredient ingredient)
    {
        // 좌클릭시
    }

    void OnRightClick(Ingredient ingredient)
    {
        // 우클릭시
        Debug.Log("재료 " + ingredient.itemName + " 클릭됨.");
    }
}
