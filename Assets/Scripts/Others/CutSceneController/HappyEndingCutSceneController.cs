using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HappyEndingCutSceneController : MonoBehaviour
{
    

    public GameObject[] cutscenes;      //�ƾ� �г� �迭

    public string sNextScene = "MainScreen";

    //�� �ƾ� ��� �迭
    public string[][] dialogList = new string[][]
    {
        //���� ���� �ƾ�
        new string[] {"���� ���� 7���� ������..." },
        new string[] {"���� ������� ��� ���Ҵ�!", "���� ġ�ڴ� ������ �ο�� ���� ���� ��...!"},
        new string[] {"Happy Ending"}
    };

    public Text dialogText;             //��� ǥ�� �ؽ�Ʈ
    public Button skipButton;           //��ŵ ��ư

    private int iCurrentCutsceneIndex = 0;  //���� �ƾ� �ε���
    private int iCurrentDialogIndex = 0;    //���� ��� �ε���

    // Start is called before the first frame update
    void Start()
    {
        ShowCutScene(0);                                    //ù��° �ƾ� ǥ��
        skipButton.onClick.AddListener(SkipCutscene);       //��ŵ ��ư �̺�Ʈ ����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))        //ȭ�� Ŭ�� ����
        {
            NextDialogOrCutScene();             //���� ��� or �ƾ� ���
        }
    }


    //���� ��� or �ƾ� ���
    void NextDialogOrCutScene()
    {
        if((iCurrentCutsceneIndex >= dialogList.Length) || (iCurrentCutsceneIndex >= cutscenes.Length))
        {
            Debug.Log("�ƾ� �ε��� ���� �ʰ�");
            return;
        }
        //���� �ƾ� ��� �����ִ� ���
        if(iCurrentDialogIndex + 1 < dialogList[iCurrentCutsceneIndex].Length)
        {
            iCurrentDialogIndex = iCurrentDialogIndex + 1;      //�ƾ� ��� �ε��� + 1
            ShowDialog(iCurrentDialogIndex);                    //���� ��� ���
        }
        //���� �ƾ� ��簡 �������� ���� ���
        else
        {
            NextCutScene();                                     //���� �ƾ� ���
        }
    }

    //���� �ƾ� ���
    void NextCutScene()
    {
        iCurrentCutsceneIndex = iCurrentCutsceneIndex + 1;  //���� �ƾ����� �ε��� �̵�
        if((iCurrentCutsceneIndex < cutscenes.Length) && (iCurrentCutsceneIndex < dialogList.Length))
        {
            ShowCutScene(iCurrentCutsceneIndex);            //���� �ƾ� ǥ��
        }
        //���� �ƾ��� ���� ���
        else
        {
            EndCutscene();                                  //�ƾ� ����
        }
    }
    //�ƾ� ���
    void ShowCutScene(int index)
    {
        //��� �ƾ� ��Ȱ��ȭ
        foreach(GameObject cutscene in cutscenes)
        {
            cutscene.SetActive(false);
        }
        //index�� �ƾ� �迭 ���̺��� ���� ���
        if((index < cutscenes.Length) && (index < dialogList.Length))
        {
            cutscenes[index].SetActive(true);       //index �ƾ� Ȱ��ȭ
            iCurrentDialogIndex = 0;                //��� �ε��� �ʱ�ȭ
            ShowDialog(iCurrentDialogIndex);        //ù��° ��� ǥ��
        }
    }
    //��� ���
    void ShowDialog(int index)
    {
        //���� �ƾ��� ��� ��� ������Ʈ
        if(index < dialogList[iCurrentCutsceneIndex].Length)
        {
            dialogText.text = dialogList[iCurrentCutsceneIndex][index]; 
        }
    }

    void SkipCutscene()
    {
        Debug.Log("�ƾ� ��ŵ");
        EndCutscene();
    }
    void EndCutscene()
    {
        Debug.Log("3�� �� �ƾ� ����");
        
        dialogText.text = "";                       //�ؽ�Ʈ �����
        skipButton.gameObject.SetActive(false);     //��ŵ ��ư �����
        Invoke("LoadMain", 0.5f);

    }
    void QuitGame()
    {
        foreach (GameObject cutscene in cutscenes)
        {
            cutscene.SetActive(false);
        }
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
    void LoadMain()
    {
        SceneManager.LoadScene(sNextScene);
    }
}
