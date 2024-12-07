using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
public class DrinkUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject drinkObj;

    void OnEnable()
    {
        // 기존 UI 제거
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // 버튼 생성
        foreach (var drink in Managers.Inventory.Drinks.Values.ToList())
        {
            if (drink.quantity == 0) continue;

            // 세로열 위치
            GameObject obj = Instantiate(drinkObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // 버튼 이미지
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = drink.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(drink));
            button.onClick.AddListener(() => OnRightClick(drink));

            // 수량 표시
            Text quantity = obj.GetComponentInChildren<Text>();
            quantity.text = drink.quantity.ToString();
        }
    }

    void OnLeftClick(Drink drink)
    {
        Managers.InGame.AddDrink(drink);
    }

    void OnRightClick(Drink drink)
    {
        // 우클릭시
        Debug.Log("주류 " + drink.itemName + " 클릭됨.");
    }
}
