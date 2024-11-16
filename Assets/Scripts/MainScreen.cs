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
        // 저장된 데이터 로드하는 부분


        SceneManager.LoadScene("InGame_Prepare");
    }
    public void OnClickExitButton() { 
        Application.Quit();
    }
}
