using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class IngredientUI : MonoBehaviour
{
    public List<Transform> posBases;
    public GameObject ingredientObj;

    void OnEnable()
    {
        // ���� UI ����
        foreach (Transform posBase in posBases)
        {
            foreach (Transform child in posBase)
            {
                Destroy(child.gameObject);
            }
        }

        // ��ư ����
        foreach (var ingredient in Managers.Inventory.Ingredients.Values.ToList())
        {
            if (ingredient.quantity == 0) continue;

            // ���ο� ��ġ
            Transform posBase = posBases[(int)ingredient.ingredientType];
            GameObject obj = Instantiate(ingredientObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = ingredient.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(ingredient));
            button.onClick.AddListener(() => OnRightClick(ingredient));

            // ���� ǥ��
            Text quantity = obj.GetComponentInChildren<Text>();
            quantity.text = ingredient.quantity.ToString();
        }
    }

    void OnLeftClick(Ingredient ingredient)
    {
        // ��Ŭ����
    }

    void OnRightClick(Ingredient ingredient)
    {
        // ��Ŭ����
        Debug.Log("��� " + ingredient.itemName + " Ŭ����.");
    }
}
