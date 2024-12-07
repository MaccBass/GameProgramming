using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class MenuBoardUI : MonoBehaviour
{
    public Transform foodPosBase;
    public Transform drinkPosBase;
    public GameObject foodMenuObj;

    void OnEnable()
    {
        UpdateFoodUI();
        UpdateDrinkUI();
    }

    private void LateUpdate()
    {
        if (Managers.InGame.foodUpdated)
        {
            UpdateFoodUI();
            Managers.InGame.foodUpdated = false;
        }

        if (Managers.InGame.drinkUpdated)
        {
            UpdateDrinkUI();
            Managers.InGame.drinkUpdated = false;
        }
    }

    void UpdateFoodUI()
    {
        // ���� UI ����
        foreach (Transform child in foodPosBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var food in Managers.InGame.Foods.ToList())
        {
            GameObject obj = Instantiate(foodMenuObj, foodPosBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = obj.transform.Find("Icon")?.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = food.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnFoodLeftClick(food));

            // ����, �̸�, ���� ǥ��
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Quantity") text.text = food.CookCount().ToString();
                else if (text.name == "Name") text.text = food.itemName;
                else if (text.name == "Price") text.text = food.sellPrice.ToString();
            }
        }
    }

    void UpdateDrinkUI()
    {
        // ���� UI ����
        foreach (Transform child in drinkPosBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var drink in Managers.InGame.Drinks.ToList())
        {
            GameObject obj = Instantiate(foodMenuObj, drinkPosBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = obj.transform.Find("Icon")?.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = drink.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnDrinkLeftClick(drink));

            // ����, �̸�, ���� ǥ��
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Quantity") text.text = drink.quantity.ToString();
                else if (text.name == "Name") text.text = drink.itemName;
                else if (text.name == "Price") text.text = drink.sellPrice.ToString();
            }
        }
    }

    void OnFoodLeftClick(Recipe food)
    {
        Managers.InGame.DeleteFood(food);
    }
    void OnDrinkLeftClick(Drink drink)
    {
        Managers.InGame.DeleteDrink(drink);
    }
}
