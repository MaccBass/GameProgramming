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
    public ToolType toolType;
    public CookerStatus status;
    public Slider cookingSlider;
    private float cookingTimer = 0;

    public Recipe recipe;
    public Recipe resultFood;

    private void Awake() {
        cookingSlider = GetComponentInChildren<Slider>(true);
        status = CookerStatus.AVAILABLE;
        if (gameObject.name == "Fryer") toolType = ToolType.Fryer;
        else if (gameObject.name == "FryingPan") toolType = ToolType.Grill;
        else if (gameObject.name == "Pot") toolType = ToolType.Pot;
        else if (gameObject.name == "CuttingBoard") toolType = ToolType.Board;
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

                Debug.Log("Cooking completed on " + toolType);
                completeFood();
            }
        }

        if (status == CookerStatus.PREPARING && Input.GetKeyDown(KeyCode.X)) {
            if (CookerManager.Instance.CookerPopup.activeSelf && CookerManager.Instance.currentRecipe != null) {
                Debug.Log(toolType + " will start cooking");
                this.startCooking();
            }
        }

        if (status == CookerStatus.COMPLETED && Input.GetKeyDown(KeyCode.X)) {
            HoldFood();
        }
    }

    public void prepareCooking() {
        if (status != CookerStatus.AVAILABLE) return;
        Debug.Log(toolType + " is preparing");
        status = CookerStatus.PREPARING;
        CookerManager.Instance.showPopup();
    }

    public void startCooking() {
        recipe = new Recipe(CookerManager.Instance.currentRecipe);
        // cooking

        status = CookerStatus.COOKING;
        cookingTimer += Time.deltaTime;
        CookerManager.Instance.hidePopup();
        cookingSlider.gameObject.SetActive(true);
    }

    public void completeFood() {
        resultFood = new Recipe(recipe);
        if (recipe.toolType != this.toolType)
            resultFood.isTrash = true;
    }

    public void HoldFood() {
        status = CookerStatus.AVAILABLE;
        cookingTimer = 0;
        cookingSlider.gameObject.SetActive(false);
        Debug.Log(resultFood.itemName);
        HeldItemsManager.Instance.HoldItem(resultFood);
        resultFood = null;
    }
}
