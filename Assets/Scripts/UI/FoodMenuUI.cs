using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
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
        // ���� UI ����
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var food in Managers.InGame.Foods.ToList())
        {
            GameObject obj = Instantiate(foodMenuObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = food.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(food));
            button.onClick.AddListener(() => OnRightClick(food));

            // ���� ǥ��
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
