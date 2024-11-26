using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneController : MonoBehaviour
{
    

    public GameObject[] cutscenes;      //컷씬 패널 배열
    
    //각 컷씬 대사 배열
    public string[][] dialogList = new string[][]
    {
        new string[] {"컷씬 1-1", "컷씬 1-2", "컷씬 1-3"},
        new string[] {"컷씬 2-1", "컷씬 2-2"},
        new string[] {"컷씬 3-1"}
    };

    public Text dialogText;             //대사 표시 텍스트
    public Button skipButton;           //스킵 버튼

    private int iCurrentCutsceneIndex = 0;  //현재 컷씬 인덱스
    private int iCurrentDialogIndex = 0;    //현재 대사 인덱스

    // Start is called before the first frame update
    void Start()
    {
        ShowCutScene(0);                                    //첫번째 컷씬 표시
        skipButton.onClick.AddListener(SkipCutscene);       //스킵 버튼 이벤트 지정
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))        //화면 클릭 감지
        {
            NextDialogOrCutScene();             //다음 대사 or 컷씬 출력
        }
    }


    //다음 대사 or 컷씬 출력
    void NextDialogOrCutScene()
    {
        if((iCurrentCutsceneIndex >= dialogList.Length) || (iCurrentCutsceneIndex >= cutscenes.Length))
        {
            Debug.Log("컷씬 인덱스 범위 초과");
            return;
        }
        //현재 컷씬 대사 남아있는 경우
        if(iCurrentDialogIndex + 1 < dialogList[iCurrentCutsceneIndex].Length)
        {
            iCurrentDialogIndex = iCurrentDialogIndex + 1;      //컷씬 대시 인덱스 + 1
            ShowDialog(iCurrentDialogIndex);                    //다음 대사 출력
        }
        //현재 컷씬 대사가 남아있지 않은 경우
        else
        {
            NextCutScene();                                     //다음 컷씬 출력
        }
    }

    //다음 컷씬 출력
    void NextCutScene()
    {
        iCurrentCutsceneIndex = iCurrentCutsceneIndex + 1;  //다음 컷씬으로 인덱스 이동
        if((iCurrentCutsceneIndex < cutscenes.Length) && (iCurrentCutsceneIndex < dialogList.Length))
        {
            ShowCutScene(iCurrentCutsceneIndex);            //다음 컷씬 표시
        }
        //다음 컷씬이 없는 경우
        else
        {
            EndCutscene();                                  //컷씬 종료
        }
    }
    //컷씬 출력
    void ShowCutScene(int index)
    {
        //모든 컷씬 비활성화
        foreach(GameObject cutscene in cutscenes)
        {
            cutscene.SetActive(false);
        }
        //index가 컷씬 배열 길이보다 작을 경우
        if((index < cutscenes.Length) && (index < dialogList.Length))
        {
            cutscenes[index].SetActive(true);       //index 컷씬 활성화
            iCurrentDialogIndex = 0;                //대사 인덱스 초기화
            ShowDialog(iCurrentDialogIndex);        //첫번째 대사 표시
        }
    }
    //대사 출력
    void ShowDialog(int index)
    {
        //현재 컷씬의 모든 대사 업데이트
        if(index < dialogList[iCurrentCutsceneIndex].Length)
        {
            dialogText.text = dialogList[iCurrentCutsceneIndex][index]; 
        }
    }

    void SkipCutscene()
    {
        Debug.Log("컷씬 스킵");
        EndCutscene();
    }
    void EndCutscene()
    {
        Debug.Log("3초 후 컷씬 종료");
        
        dialogText.text = "";                       //텍스트 지우기
        skipButton.gameObject.SetActive(false);     //스킵 버튼 숨기기

        //임시: 3초 후 게임 종료
        Invoke("QuitGame", 3.0f);
    }
    void QuitGame()
    {
        foreach (GameObject cutscene in cutscenes)
        {
            cutscene.SetActive(false);
        }
        //임시: 테스트 모드시 종료
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
