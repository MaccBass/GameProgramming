using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookerManager : MonoBehaviour
{
    public static CookerManager Instance { get; private set; }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public GameObject RecipePopup;
    public GameObject itemPrefab;

    public Transform Content;
    public Transform Body;
    public Transform Footer;
    public Transform SelectedRecipe;
    public Transform IngredientsContainer;
    public List<Transform> Ingredients;

    public GameObject currentSelectedRecipeUI;
    public Recipe currentRecipe;
    public List<Ingredient> currentIngredients;

    public void Start() {
        Content = RecipePopup.transform.Find("Content");
        Body = Content.Find("Body");
        Footer = Content.Find("Footer");
        SelectedRecipe = Footer.Find("SelectedRecipe");

        IngredientsContainer = Footer.Find("IngredientsContainer");
        Ingredients = new List<Transform>();
        foreach (Transform i in IngredientsContainer) {
            Ingredients.Add(i);
        }
    }

    // popup
    public void showPopup() {
        UpdateRecipes();
        RecipePopup.SetActive(true);
    }

    public void UpdateRecipes() {
        foreach (Transform child in Body) {
            Destroy(child.gameObject);
        }
        foreach (var recipe in Managers.Prepare.Foods)
        {
            GameObject obj = Instantiate(itemPrefab, Body);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null) {
                iconImage.sprite = recipe.icon;
            }

            button.onClick.AddListener(() => OnLeftClick(recipe, obj));
        }
    }

    public void hidePopup() {
        RecipePopup.SetActive(false);
    }

    void OnLeftClick(Recipe recipe, GameObject prefab) {
        if (currentSelectedRecipeUI != null) {
            Destroy(currentSelectedRecipeUI);
        }
        currentRecipe = recipe;
        currentSelectedRecipeUI = Instantiate(prefab, SelectedRecipe);
        currentSelectedRecipeUI.GetComponent<Image>().sprite = recipe.icon;
        Button selectedButton = currentSelectedRecipeUI.GetComponent<Button>();
        selectedButton.onClick.RemoveAllListeners();
        selectedButton.onClick.AddListener(ClearSelection);

        currentSelectedRecipeUI.GetComponentInChildren<Text>().text = recipe.name;
    }

    void ClearSelection() {
        if (currentSelectedRecipeUI != null) {
            Destroy(currentSelectedRecipeUI);
            currentSelectedRecipeUI = null;
        }
    }

    public void AddIngredient(Ingredient ingredient) {
        currentIngredients.Add(ingredient);
        UpdateIngredientsUI();
    }

    public void UpdateIngredientsUI() {
        foreach (Transform child in IngredientsContainer) {
            Destroy(child.gameObject);
        }

        foreach (var ingredient in currentIngredients) {
            GameObject ingredientUI = Instantiate(itemPrefab, IngredientsContainer);
            ingredientUI.GetComponent<Image>().sprite = ingredient.icon;

            Button button = ingredientUI.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => HandleIngredientSelection(ingredient));

            Text label = ingredientUI.GetComponentInChildren<Text>();
            if (label != null) {
                label.text = ingredient.itemName;
            }
        }
    }

    private void HandleIngredientSelection(Ingredient ingredient) {
        if (HeldItemsManager.Instance.canHold()) {
            currentIngredients.Remove(ingredient);
            HeldItemsManager.Instance.HoldItem(ingredient);
            UpdateIngredientsUI();
            HeldItemsManager.Instance.UpdateUI();
        }
    }

    // cooking
    public void startCooking(Item cooker, Recipe menu) {
        // menu.time동안 요리
        // if ()
    }
}
