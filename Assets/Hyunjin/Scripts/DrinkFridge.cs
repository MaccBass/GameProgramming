// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DrinkFridge : MonoBehaviour
// {
//     public GameObject DrinkFridgePopup;
//     public Transform DrinkFridgeContainer;
//     public GameObject itemPrefab;
//     public bool isActive = false;
//     public List<Drink> FridgeDrink;

//     public void AddItem(Drink drink) {
//         FridgeDrink.Add(drink);
//         UpdateUI();
//     }
    
//     public void DeleteItem(Drink drink) {
//         if (!HeldItemsManager.Instance.canHold())
//             return;
//         FridgeDrink.Remove(drink);
//         UpdateUI();
//         HeldItemsManager.Instance.HoldItem(drink);
//     }

//     public void UpdateUI() {
//         foreach (Transform child in FridgeContainer) {
//             Destroy(child.gameObject);
//         }
//         foreach (Recipe recipe in FridgeRecipe)
//         {
//             GameObject obj = Instantiate(itemPrefab, FridgeContainer);
//             Button button = obj.GetComponent<Button>();
//             button.transform.localScale = Vector3.one;

//             Image iconImage = button.GetComponent<Image>();
//             if (iconImage != null) {
//                 iconImage.sprite = recipe.icon;
//             }
//             Text label = button.GetComponentInChildren<Text>();
//             if (label != null)
//                 label.text = recipe.itemName;

//             button.onClick.AddListener(() => DeleteItem(recipe));
//         }
//     }
    
//     public void showPopup() {
//         isActive = true;
//         UpdateUI();
//         FridgePopup.SetActive(true);
//     }
    
//     public void hidePopup() {
//         isActive = false;
//         FridgePopup.SetActive(false);
//     }
// }
