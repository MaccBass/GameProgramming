using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
public class FoodMenuUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject foodMenuObj;

    void OnEnable()
    {
        UpdateUI();
    }

    private void LateUpdate()
    {
        if (Managers.InGame.foodUpdated)
        {
            UpdateUI();
            Managers.InGame.foodUpdated = false;
        }
    }

    void UpdateUI()
    {
        // 기존 UI 제거
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // 버튼 생성
        foreach (var food in Managers.InGame.Foods.ToList())
        {
            GameObject obj = Instantiate(foodMenuObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // 버튼 이미지
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = food.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(food));
            button.onClick.AddListener(() => OnRightClick(food));

            // 수량 표시
            Text toolLevel = obj.GetComponentInChildren<Text>();
            toolLevel.text = food.foodName.ToString();
        }
    }

    void OnLeftClick(Recipe food)
    {
        Managers.InGame.deleteFood(food);
    }

    void OnRightClick(Recipe food)
    {

    }
}
