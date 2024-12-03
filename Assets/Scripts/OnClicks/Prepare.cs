using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prepare : MonoBehaviour
{
    public GameObject menuSelectWindow;
    public GameObject drinkSelectWindow;
    public GameObject ingredientWindow;
    public GameObject toolWindow;
    public GameObject employeeWindow;

    void Start()
    {
        menuSelectWindow.SetActive(true);
        drinkSelectWindow.SetActive(false);
        ingredientWindow.SetActive(false);
        toolWindow.SetActive(false);
        employeeWindow.SetActive(false);
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
        SceneManager.LoadScene("InGame_Open");
    }
}
