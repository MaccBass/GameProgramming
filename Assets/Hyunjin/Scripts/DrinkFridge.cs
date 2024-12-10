using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkFridge : MonoBehaviour
{
    public GameObject DrinkFridgePopup;
    public Transform DrinkFridgeContainer;
    public GameObject itemPrefab;
    public bool isActive = false;

    public void AddItem(Drink drink) {
        drink.quantity++;
        UpdateUI();
    }
    
    public void DeleteItem(Drink drink) {
        if (drink.quantity <= 0 || !HeldItemsManager.Instance.canHold())
            return;
        drink.quantity--; // 수량 줄어드는거맞나?
        UpdateUI();
        HeldItemsManager.Instance.HoldItem(drink);
    }

    public void UpdateUI() {
        foreach (Transform child in DrinkFridgeContainer) {
            Destroy(child.gameObject);
        }
        foreach (Drink drink in Managers.Prepare.Drinks)
        {
            GameObject obj = Instantiate(itemPrefab, DrinkFridgeContainer);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null) {
                iconImage.sprite = drink.icon;
            }
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts) {
                if (text.gameObject.name == "Name")
                    text.text = drink.itemName;
                else if (text.gameObject.name == "Quantity")
                    text.text = drink.quantity.ToString();
            }

            button.onClick.AddListener(() => DeleteItem(drink));
        }
    }
    
    public void showPopup() {
        isActive = true;
        UpdateUI();
        DrinkFridgePopup.SetActive(true);
    }
    
    public void hidePopup() {
        isActive = false;
        DrinkFridgePopup.SetActive(false);
    }
}
