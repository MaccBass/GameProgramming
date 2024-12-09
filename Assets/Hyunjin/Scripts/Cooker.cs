using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CookerStatus {
    AVAILABLE,
    PREPARING,
    COOKING,
    COMPLETED
}

public class Cooker : MonoBehaviour
{
    public ToolType tooltype;
    public CookerStatus status;
    public Slider cookingSlider;
    private float cookingTimer = 0;

    public Recipe recipe;
    public List<Ingredient> ingredients;

    private void Awake() {
        cookingSlider = GetComponentInChildren<Slider>(true); // Include inactive children
        status = CookerStatus.AVAILABLE;
        if (gameObject.name == "") toolType = ToolType.Fryer;
        else if (gameObject.name == "") toolType = ToolType.Grill;
        else if (gameObject.name == "") toolType = ToolType.Pot;
        else if (gameObject.name == "") toolType = ToolType.Board;
    }

    private void Start() {
        cookingSlider.gameObject.SetActive(false);
    }

    public void Update() {
        if (status == CookerStatus.COOKING) {
            cookingTimer += Time.deltaTime;
            cookingSlider.value = cookingTimer / recipe.cookingTime;
            if (cookingTimer >= recipe.cookingTime) {
                cookingTimer = 0;
                status = CookerStatus.COMPLETED;
                Debug.Log("Cooking completed on " + type);
            }
        }

        if (status == CookerStatus.PREPARING && Input.GetKeyDown(KeyCode.X)) {
            if (CookerManager.Instance.RecipePopup.activeSelf && CookerManager.Instance.currentSelectedRecipeUI != null && CookerManager.Instance.currentIngredients.Count > 0) {
                Debug.Log(type + " will start cooking");
                this.startCooking();
            }
        }

        if (status == CookerStatus.COMPLETED && Input.GetKeyDown(KeyCode.X)) {
            HoldFood();
        }
    }

    public void prepareCooking() {
        if (status != CookerStatus.AVAILABLE) return;
        Debug.Log(type + " is preparing");
        status = CookerStatus.PREPARING;
        CookerManager.Instance.showPopup();
    }

    public void startCooking() {
        recipe = Recipe(CookerManager.Instance.currentRecipe);
        ingredients = new List<Ingredient>(CookerManager.Instance.currentIngredients); // 계속 바뀌므로 new 해야됨

        // cooking

        status = CookerStatus.COOKING;
        cookingTimer += Time.deltaTime;
        CookerManager.Instance.hidePopup();
        cookingSlider.gameObject.SetActive(true);
    }

    public void completeFood() {
        Recipe resultFood = Recipe(recipe);
        if (recipe.toolType != this.toolType)
            resultFood.isTrash = true;
        // foreach(recip.ingredients)//////////////////////// 재료 다르면 true
    }

    public void HoldFood() {
        status = CookerStatus.AVAILABLE;
        cookingTimer = 0;
        cookingSlider.gameObject.SetActive(false);
        HeldItemsManager.Instance.HoldItem(resultFood);
    }
}
