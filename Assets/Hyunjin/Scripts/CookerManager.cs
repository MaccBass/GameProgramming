using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public List<GameObject> cookers;

    private Cooker currentCooker;
    private bool selected;

    public void Start() {
        foreach (var tool in Managers.Prepare.Tools.ToList())
        {
            int idx = (int)tool.toolType;
            GameObject obj = Instantiate(cookers[idx]);
            obj.transform.position = new Vector3(-6.0f + 1.25f * idx, 3.5f, 0f);
        }
        foreach (Recipe recipe in Managers.Prepare.Foods)
        {
            GameObject obj = Instantiate(itemPrefab, CookerContainer);
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

            button.onClick.AddListener(() => OnLeftClick(recipe));
        }
    }

    void OnLeftClick(Recipe recipe) {
        selected = true;
        currentCooker.startCooking(recipe);
        currentCooker = null;
        hidePopup();
    }

    // popup
    public void showPopup(Cooker target) {
        currentCooker = target;
        CookerPopup.SetActive(true); 
    }

    public void hidePopup() {
        if (!selected)
            currentCooker.status = CookerStatus.AVAILABLE;
        selected = false;
        CookerPopup.SetActive(false);
    }
}
