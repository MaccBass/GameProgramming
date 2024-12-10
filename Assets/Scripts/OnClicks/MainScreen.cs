using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void OnClickGameStartButton()
    {
        Managers.Inventory.Init("NewGame");
        Managers.Prepare.Init("NewGame");
        Managers.Market.Init("NewGame");
        Managers.Status.Init();
        Managers.InGame.Init();
        // SceneManager.LoadScene("CutScene_NewGame");
        SceneManager.LoadScene("1. Opening CutScene");
    }
    public void OnClickExitButton() 
    { 
        Application.Quit();
    }
}
