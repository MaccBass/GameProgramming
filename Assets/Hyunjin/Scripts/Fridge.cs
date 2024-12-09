using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Fridge : MonoBehaviour
{
    public GameObject FridgePopup;
    public Transform FridgeContainer;
    public GameObject itemPrefab;
    public bool isActive = false;

    public void showPopup() {
        isActive = true;
        UpdateIngredients();
        FridgePopup.SetActive(true);
    }
    
    public void UpdateIngredients() {
        foreach (Transform child in FridgeContainer) {
            Destroy(child.gameObject);
        }

        foreach (var ingredient in Managers.Inventory.Ingredients.Values.ToList())
        {
            // Debug.Log(ingredient);
            if (ingredient.quantity == 0) {
                continue;
            }

            GameObject obj = Instantiate(itemPrefab, FridgeContainer);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null) {
                iconImage.sprite = ingredient.icon;
            }

            Text quantity = obj.GetComponentInChildren<Text>();
            quantity.text = ingredient.quantity.ToString();
            button.onClick.AddListener(() => OnLeftClick(ingredient));
        }
    }
   
    public void hidePopup() {
        isActive = false;
        FridgePopup.SetActive(false);
    }

    void OnLeftClick(Ingredient ingredient) {
        if (ingredient.quantity <= 0 || !HeldItemsManager.Instance.canHold())
            return;
        ingredient.quantity--;
        UpdateIngredients();
        HeldItemsManager.Instance.HoldItem(ingredient);
    }
}
