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

    public Recipe targetRecipe;
    public Recipe resultRecipe;

    private void Awake() {
        cookingSlider = GetComponentInChildren<Slider>(true);
        cookingSlider.gameObject.SetActive(false);
        status = CookerStatus.AVAILABLE;
        if (gameObject.name == "Fryer") toolType = ToolType.Fryer;
        else if (gameObject.name == "FryingPan") toolType = ToolType.Grill;
        else if (gameObject.name == "Pot") toolType = ToolType.Pot;
        else if (gameObject.name == "CuttingBoard") toolType = ToolType.Board;
    }

    public void Update() {
        if (status == CookerStatus.COOKING) {
            cookingTimer += Time.deltaTime;
            cookingSlider.value = cookingTimer / targetRecipe.cookingTime;
            if (cookingTimer >= targetRecipe.cookingTime) {
                cookingTimer = 0;
                status = CookerStatus.COMPLETED;

                Debug.Log("Cooking completed on " + toolType);
                completeFood();
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

        CookerManager.Instance.showPopup(this);
    }

    public void startCooking(Recipe recipe) {
        targetRecipe = recipe;

        status = CookerStatus.COOKING;
        cookingTimer += Time.deltaTime;
        cookingSlider.gameObject.SetActive(true);
    }

    public void completeFood() {
        resultRecipe = new Recipe(targetRecipe);
        if (targetRecipe.toolType != this.toolType) {
            resultRecipe.isTrash = true;
            Debug.Log("TRASH!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }

    public void HoldFood() {
        status = CookerStatus.AVAILABLE;
        cookingTimer = 0;
        cookingSlider.gameObject.SetActive(false);
        Debug.Log(resultRecipe.itemName);
        HeldItemsManager.Instance.HoldItem(resultRecipe);
        resultRecipe = null;
    }
}
