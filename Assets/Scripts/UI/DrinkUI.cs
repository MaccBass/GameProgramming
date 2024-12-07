using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class DrinkUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject drinkObj;

    void OnEnable()
    {
        // ���� UI ����
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var drink in Managers.Inventory.Drinks.Values.ToList())
        {
            if (drink.quantity == 0) continue;

            // ���ο� ��ġ
            GameObject obj = Instantiate(drinkObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = drink.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(drink));
            button.onClick.AddListener(() => OnRightClick(drink));

            // ���� ǥ��
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
        // ��Ŭ����
        Debug.Log("�ַ� " + drink.itemName + " Ŭ����.");
    }
}
