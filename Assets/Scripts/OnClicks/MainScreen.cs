using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void OnClickGameStartButton()
    {
        Managers.Inventory.Init("NewGame");
        Managers.InGame.Init("NewGame");
        Managers.Market.Init("NewGame");
        // SceneManager.LoadScene("CutScene_NewGame");
        SceneManager.LoadScene("InGame_Prepare_LIS");
    }
    public void OnClickGameLoadButton()
    {
        // ����� ������ �ε��ϴ� �κ�
        // SceneManager.LoadScene("InGame_Prepare");
        SceneManager.LoadScene("InGame_Prepare_LIS");
    }
    public void OnClickExitButton() { 
        Application.Quit();
    }
}
