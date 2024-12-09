using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CookerStatus {
    AVAILABLE,
    COOKING,
    COMPLETED
}

public enum ResultStatus {
    NONE,
    GOOD,
    BAD
}

public class Cooker : MonoBehaviour
{
    public string type;
    public CookerStatus status;
    // public Slider cookingSlider;
    private float cookingTimer = 0;

    public Recipe recipe;
    public List<Ingredient> ingredients;
    public ResultStatus result;

    private void Start() {
        status = CookerStatus.AVAILABLE;
        type = gameObject.name;

        // cookingSlider = GetComponentInChildren<Slider>();
        // cookingSlider.gameObject.SetActive(false);
    }

    public void Update() {
        if (status == CookerStatus.COOKING) {
            cookingTimer += Time.deltaTime;
            // cookingSlider.value = cookingTimer / recipe.cookingTime;
            if (cookingTimer >= recipe.cookingTime) {
                cookingTimer = 0;
                status = CookerStatus.COMPLETED;
                Debug.Log("Cooking completed on " + type);
            }
        }

        if (status == CookerStatus.AVAILABLE && Input.GetKeyDown(KeyCode.Z)) {
            if (CookerManager.Instance.RecipePopup.activeSelf && CookerManager.Instance.currentSelectedRecipeUI != null && CookerManager.Instance.currentIngredients.Count > 0) {
                Debug.Log(status + "(Update)");
                startCooking();
            }
        }
    }

    public void prepareCooking() {
        if (status != CookerStatus.AVAILABLE) return;
        Debug.Log(type + "is preparing");
        CookerManager.Instance.showPopup();
    }

    public void startCooking() {
        recipe = CookerManager.Instance.currentRecipe;
        ingredients = CookerManager.Instance.currentIngredients; // 계속 바뀌므로 new 해야됨

        status = CookerStatus.COOKING;
        cookingTimer += Time.deltaTime;
        Debug.Log("start cooking ! " + type + " - " + recipe);
        CookerManager.Instance.hidePopup();
    }

    public void CleanCooker() {
        status = CookerStatus.AVAILABLE;
        result = ResultStatus.NONE;
        cookingTimer = 0;
        // cookingSlider.gameObject.SetActive(false);
    }
}
