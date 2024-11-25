using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneController : MonoBehaviour
{
    public GameObject[] cutscenes;      //ÄÆ¾À ÆÐ³Î ¹è¿­
    private int iCurrentCutsceneIndex = 0;  //ÇöÀç ÄÆ¾À ÀÎµ¦½º
    public Button skipButton;           //½ºÅµ ¹öÆ°
    // Start is called before the first frame update
    void Start()
    {
        ShowCutScene(0);
        skipButton.onClick.AddListener(SkipCutscene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextCutScene();
        }
    }

    void NextCutScene()
    {
        iCurrentCutsceneIndex = iCurrentCutsceneIndex + 1;
        if(iCurrentCutsceneIndex < cutscenes.Length)
        {
            ShowCutScene(iCurrentCutsceneIndex);
        }
        else
        {
            EndCutscene();
        }
    }
    void ShowCutScene(int index)
    {
        foreach(GameObject cutscene in cutscenes)
        {
            cutscene.SetActive(false);
        }
        if(index < cutscenes.Length)
        {
            cutscenes[index].SetActive(true);
        }
    }
    void SkipCutscene()
    {
        Debug.Log("ÄÆ¾À ½ºÅµ");
        EndCutscene();
    }
    void EndCutscene()
    {
        Debug.Log("ÄÆ¾À Á¾·á");
    }
}
