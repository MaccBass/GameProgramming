using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class CartUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject cartObj;
    public Text totalPrice;

    void OnEnable()
    {
        UpdateCartUI();
    }

    private void LateUpdate()
    {
        if (Managers.Market.cartUpdated)
        {
            UpdateCartUI();
            Managers.Market.cartUpdated = false;
        }
    }

    void UpdateCartUI()
    {
        // ���� UI ����
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var item in Managers.Market.Cart)
        {
            GameObject obj = Instantiate(cartObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = item.Key.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnFoodLeftClick(item.Key));

            // ����, �̸�, ���� ǥ��
            Text quantity = obj.GetComponentInChildren<Text>();
            quantity.text = item.Value.ToString();
        }

        totalPrice.text = Managers.Market.totalPrice.ToString();
    }

    void OnFoodLeftClick(Item item)
    {
        Managers.Market.DeleteCart(item);
    }

    public void OnPurchaseButtonClick()
    {
        Managers.Market.BuyCart();
    }
}
