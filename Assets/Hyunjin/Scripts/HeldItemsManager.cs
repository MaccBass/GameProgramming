using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldItemsManager : MonoBehaviour
{
    public static HeldItemsManager Instance { get; private set; }
    
    public GameObject Fridge;
    public GameObject DrinkFridge;
    // public GameObject Recipe; // cooker????
    private List<(Item item, bool isSelected)> HeldItemList;
    public GameObject HeldItemPrefab;
    public GameObject[] heldItemUI;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        HeldItemList = new List<(Item, bool)>();
    }

    private void Start() {
        heldItemUI = new GameObject[5]; // 최대 5개의 아이템을 표시할 수 있음
        for (int i = 0; i < heldItemUI.Length; i++) {
            heldItemUI[i] = Instantiate(HeldItemPrefab, transform);
            heldItemUI[i].SetActive(false); // 기본적으로 비활성화
        }
    }

    private void Update() {
        KeyboardInput();
    }

    private void KeyboardInput() {
        for (int i = 0; i < 5; i++) {
            if (Input.GetKeyDown((KeyCode)('1'+i))) {
                if (i < HeldItemList.Count)
                    SelectItem(i);
            }
        }
    }

    private void SelectItem(int index) {
        var (item, isSelected) = HeldItemList[index];

        isSelected = !isSelected;
        HeldItemList[index] = (item, isSelected);
        UpdateUI();
        if (isSelected) {
            Collider2D collider = Temp_PlayerController.Instance.getRay();
            // 콜라이더가 테이블이면 서빙

            if (collider != null)
            {
                if (collider.gameObject.layer == 9)
                {
                    ServeItem(index, collider.gameObject.GetComponentInChildren<Customer>());
                }
                // Fridge면 item==Recipe일 때 보관
                else if (collider.name == "Fridge" && item is Recipe recipe)
                {
                    ReleaseRecipe(index);
                }
                // DrinkFridge면 item==Drink일 때 보관
                else if (collider.name == "DrinkFridge" && item is Drink drink)
                {
                    ReleaseDrink(index);
                }
                else if (collider.name == "TrashCan")
                {
                    ThrowAway(index);
                }
            }
        }
    }
    
    public void HoldItem(Item item) {
        if (HeldItemList.Count >= 5) return;

        HeldItemList.Add((item, false));
        UpdateUI();
    }

    public void ServeItem(int index, Customer customer) {
        if (Temp_OrderManager.Instance.ServeOrder(HeldItemList[index].item, customer)) {
            HeldItemList.RemoveAt(index);
            UpdateUI();
        }
    }

    public void ReleaseRecipe(int index) {
        if (HeldItemList[index].item is Recipe recipe) {
            Fridge.GetComponent<Fridge>().AddItem(recipe);
        }
        HeldItemList.RemoveAt(index);
        UpdateUI();
    }

    public void ReleaseDrink(int index) {
        if (HeldItemList[index].item is Drink drink) {
            DrinkFridge.GetComponent<DrinkFridge>().AddItem(drink);
        }
        HeldItemList.RemoveAt(index);
        UpdateUI();
    }
    
    public void ThrowAway(int index) {
        HeldItemList.RemoveAt(index);
        UpdateUI();
    }

    public bool canHold() {
        return(HeldItemList.Count < 5);
    }

    public void UpdateUI() { // 만약 selected라면 !!!!!!!!!!!!!!!!!
        // 모든 UI 아이템을 비활성화
        foreach (GameObject itemUI in heldItemUI) {
            itemUI.SetActive(false);
        }

        // HeldItemList에 있는 아이템에 대한 UI 활성화
        for (int i = 0; i < HeldItemList.Count; i++) {
            Item item = HeldItemList[i].item;
            heldItemUI[i].SetActive(true);
            heldItemUI[i].GetComponent<Image>().sprite = item.icon;
            heldItemUI[i].GetComponent<Button>().onClick.RemoveAllListeners();
            int currentIndex = i;
            heldItemUI[i].GetComponent<Button>().onClick.AddListener(() => SelectItem(currentIndex));
        }
    }
}
