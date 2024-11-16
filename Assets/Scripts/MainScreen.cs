using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void OnClickGameStartButton()
    {
        SceneManager.LoadScene("CutScene_NewGame");
    }
    public void OnClickGameLoadButton()
    {
        // ����� ������ �ε��ϴ� �κ�


        SceneManager.LoadScene("InGame_Prepare");
    }
    public void OnClickExitButton() { 
        Application.Quit();
    }
}
