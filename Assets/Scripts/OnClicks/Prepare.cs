using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prepare : MonoBehaviour
{
    public GameObject menuSelectWindow;
    public GameObject marketWindow;
    public GameObject staffWindow;

    void Start()
    {
        menuSelectWindow.SetActive(true);
        marketWindow.SetActive(false);
        staffWindow.SetActive(false);
    }

    public void OnClickMenuSelectButton()
    {
        menuSelectWindow.SetActive(true);
        marketWindow.SetActive(false);
        staffWindow.SetActive(false);
    }
    public void OnClickMarKetButton()
    {
        menuSelectWindow.SetActive(false);
        marketWindow.SetActive(true);
        staffWindow.SetActive(false);
    }
    public void OnClickEmployeeButton()
    {
        menuSelectWindow.SetActive(false);
        marketWindow.SetActive(false);
        staffWindow.SetActive(true);
    }

    public void OnClickOpenButton()
    {
        SceneManager.LoadScene("InGame_Open");
    }
}
