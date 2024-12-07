using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject buttonObj;

    public void UpdateIngredientUI()
    {
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        foreach (var ingredient in Managers.Market.Ingredients.ToList())
        {
            GameObject obj = Instantiate(buttonObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = obj.transform.Find("Icon")?.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = ingredient.icon;
            }

            button.onClick.AddListener(() => OnItemLeftClick(ingredient));
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach(Text text in texts)
            {
                if (text.name == "Quantity") text.text = "";
                else if (text.name == "Name") text.text = ingredient.itemName;
                else if (text.name == "Price") text.text = ingredient.purchasePrice.ToString();
            }
        }
    }

    public void UpdateDrinkUI()
    {
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        foreach (var drink in Managers.Market.Drinks.ToList())
        {
            GameObject obj = Instantiate(buttonObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = obj.transform.Find("Icon")?.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = drink.icon;
            }

            button.onClick.AddListener(() => OnItemLeftClick(drink));
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Quantity") text.text = "";
                else if (text.name == "Name") text.text = drink.itemName;
                else if (text.name == "Price") text.text = drink.purchasePrice.ToString();
            }
        }
    }
    public void UpdateRecipeUI()
    {
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        foreach (var recipe in Managers.Market.Recipes.ToList())
        {
            if (Managers.Inventory.Recipes[recipe.itemName].isObtained) continue;

            GameObject obj = Instantiate(buttonObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = obj.transform.Find("Icon")?.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = recipe.icon;
            }

            button.onClick.AddListener(() => OnItemLeftClick(recipe));
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Quantity") text.text = "";
                else if (text.name == "Name") text.text = recipe.itemName;
                else if (text.name == "Price") text.text = recipe.purchasePrice.ToString();
            }
        }
    }
    public void UpdateToolUI()
    {
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        foreach (var tool in Managers.Market.Tools.ToList())
        {
            GameObject obj = Instantiate(buttonObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = obj.transform.Find("Icon")?.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = tool.icon;
            }

            button.onClick.AddListener(() => OnItemLeftClick(tool));
            Text[] texts = obj.GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name == "Quantity") text.text = "";
                else if (text.name == "Name") text.text = tool.itemName;
                else if (text.name == "Price") text.text = tool.purchasePrice.ToString();
            }
        }
    }

    // 아이템 눌렀을 시 함수들
    void OnItemLeftClick(Item item)
    {
        Managers.Market.AddCart(item);
    }
}
