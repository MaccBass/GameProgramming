using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prepare : MonoBehaviour
{
    // 총괄
    public GameObject prepareWindow;
    public GameObject marketWindow;

    // PrepareScreen
    public GameObject menuSelectWindow;
    public GameObject drinkSelectWindow;
    public GameObject ingredientWindow;
    public GameObject toolWindow;
    public GameObject employeeWindow;

    // MarketScreen

    void Start()
    {
        prepareWindow.SetActive(true);
        marketWindow.SetActive(false);

        menuSelectWindow.SetActive(true);
        drinkSelectWindow.SetActive(false);
        ingredientWindow.SetActive(false);
        toolWindow.SetActive(false);
        employeeWindow.SetActive(false);
    }
    public void OnClickMarketButton()
    {
        prepareWindow.SetActive(false);
        marketWindow.SetActive(true);
    }
    public void OnClickPrepareButton()
    {
        prepareWindow.SetActive(true);
        marketWindow.SetActive(false);
    }

    public void OnClickMenuSelectButton()
    {
        menuSelectWindow.SetActive(true);
        drinkSelectWindow.SetActive(false);
        ingredientWindow.SetActive(false);
        toolWindow.SetActive(false);
        employeeWindow.SetActive(false);
    }
    public void OnClickDrinkSelectButton()
    {
        menuSelectWindow.SetActive(false);
        drinkSelectWindow.SetActive(true);
        ingredientWindow.SetActive(false);
        toolWindow.SetActive(false);
        employeeWindow.SetActive(false);
    }
    public void OnClickIngredientButton()
    {
        menuSelectWindow.SetActive(false);
        drinkSelectWindow.SetActive(false);
        ingredientWindow.SetActive(true);
        toolWindow.SetActive(false);
        employeeWindow.SetActive(false);
    }
    public void OnclickToolButton()
    {
        menuSelectWindow.SetActive(false);
        drinkSelectWindow.SetActive(false);
        ingredientWindow.SetActive(false);
        toolWindow.SetActive(true);
        employeeWindow.SetActive(false);
    }
    public void OnclickEmployeeButton()
    {
        menuSelectWindow.SetActive(false);
        drinkSelectWindow.SetActive(false);
        ingredientWindow.SetActive(false);
        toolWindow.SetActive(false);
        employeeWindow.SetActive(true);
    }

    public void OnClickOpenButton()
    {
        if (Managers.Prepare.Foods.Count <= 0)
        {
            Debug.Log("음식을 1종류 이상 편성해야 함.");
            return;
        }/*
        if (Managers.Prepare.Drinks.Count <= 0)
        {
            Debug.Log("주류를 1종류 이상 편성해야 함.");
            return;
        }*/
        if (Managers.Prepare.Tools.Count <= 0)
        {
            Debug.Log("도구를 1종류 이상 편성해야 함.");
            return;
        }
        SceneManager.LoadScene("Open_Customer");
    }
}
