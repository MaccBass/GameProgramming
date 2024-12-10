
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
    public List<Recipe> FridgeRecipe;

    public void AddItem(Recipe recipe) {
        FridgeRecipe.Add(recipe);
        UpdateUI();
    }
    
    public void DeleteItem(Recipe recipe) {
        if (!HeldItemsManager.Instance.canHold())
            return;
        FridgeRecipe.Remove(recipe);
        UpdateUI();
        HeldItemsManager.Instance.HoldItem(recipe);
    }

    public void UpdateUI() {
        foreach (Transform child in FridgeContainer) {
            Destroy(child.gameObject);
        }
        foreach (Recipe recipe in FridgeRecipe)
        {
            GameObject obj = Instantiate(itemPrefab, FridgeContainer);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null) {
                iconImage.sprite = recipe.icon;
            }
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts) {
                if (text.gameObject.name == "Name")
                    text.text = recipe.itemName;
            }

            button.onClick.AddListener(() => DeleteItem(recipe));
        }
    }
    
    public void showPopup() {
        isActive = true;
        UpdateUI();
        FridgePopup.SetActive(true);
    }
    
    public void hidePopup() {
        isActive = false;
        FridgePopup.SetActive(false);
    }
}
