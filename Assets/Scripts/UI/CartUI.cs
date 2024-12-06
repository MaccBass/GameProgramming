using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
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
        // 기존 UI 제거
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // 버튼 생성
        foreach (var item in Managers.Market.Cart)
        {
            GameObject obj = Instantiate(cartObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // 버튼 이미지
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = item.Key.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnFoodLeftClick(item.Key));

            // 수량, 이름, 가격 표시
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
