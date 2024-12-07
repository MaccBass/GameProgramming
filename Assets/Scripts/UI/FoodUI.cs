using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class FoodUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject menuObj;

    void OnEnable()
    {
        // ���� UI ����
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var recipe in Managers.Inventory.Recipes.Values.ToList())
        {
            if (!recipe.isObtained) continue;

            GameObject obj = Instantiate(menuObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = recipe.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(recipe));
            button.onClick.AddListener(() => OnRightClick(recipe));

            // ���� ǥ��
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
        // ��Ŭ����
        Debug.Log("�޴� " + recipe.itemName + " Ŭ����.");
    }
}
