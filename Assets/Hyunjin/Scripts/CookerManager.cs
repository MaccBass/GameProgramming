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

    public GameObject CookerPopup;
    public Transform CookerContainer;
    public GameObject itemPrefab;
    public List<Recipe> CookerRecipe;

    public Recipe currentRecipe;

    public void Start() {
        foreach (Recipe recipe in Managers.Prepare.Foods)
        {
            GameObject obj = Instantiate(itemPrefab, CookerContainer);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null) {
                iconImage.sprite = recipe.icon;
            }

            button.onClick.AddListener(() => OnLeftClick(recipe));
        }
    }

    void OnLeftClick(Recipe recipe) {
        currentRecipe = recipe;
    }

    // popup
    public void showPopup() {
        CookerPopup.SetActive(true);
    }

    public void hidePopup() {
        CookerPopup.SetActive(false);
    }
}
