using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp_UIManager : MonoBehaviour
{
    public static Temp_UIManager Instance { get; private set; }

    // top area
    public Text dayText;
    public Text revenueText;
    public Slider timeSlider;
    public Button pauseButton;
    public Button ResumeButton;
    public GameObject PauseMenu;
    // customer UI
    public GameObject reviewUIPrefab;
    // popup
    public GameObject FridgePopup;
    public GameObject RecipePopup;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // top area
    public void UpdateDay(int day) {
        dayText.text = $"DAY {day}";
    }
    public void UpdateDailyRevenue(int revenue) {
        revenueText.text = $"{revenue}원";
    }
    public void UpdateTimeBar(float progress) {
        timeSlider.value = progress;
    }
    public void OnPauseButtonClicked() {
        Temp_GameManager.Instance.PauseGame();
        showPauseMenu();
    }
    public void OnResumeButtonClicked() {
        Temp_GameManager.Instance.ResumeGame();
        hidePauseMenu();
    }
    public void showPauseMenu() {
        Debug.Log("showPausesMenu()");
        PauseMenu.SetActive(true);
    }
    public void hidePauseMenu() {
        PauseMenu.SetActive(false);
    }

    // customer UI
    public void ShowPaymentSatisfaction(Vector3 position, int payment, int satisfaction) {
        GameObject reviewUI = Instantiate(reviewUIPrefab, position, Quaternion.identity);
        Text[] reviewTexts = reviewUI.GetComponentsInChildren<Text>();
        reviewTexts[0].text = payment + "원";
        reviewTexts[1].text = satisfaction + "점";
        Destroy(reviewUI, 3f);
    }

    // popop
    public bool isPopupActive() {
        return (FridgePopup.activeSelf || RecipePopup.activeSelf);
    }
}
