using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour
{
    public Button nextButton;           //다음날로 넘어가는 버튼
    public string sNextScene = "InGame_Prepare";            
    private string sHappyEnding = "2. HappyEnding CutScene";    //해피 엔딩 컷씬
    private string sBadEnding = "3. BadEnding CutScene";        //배드 엔딩 컷씬

    private int iDay;                   //일차 변수
    private int iMoneyToPayLoan;
    private DailyResults dailyResults;                  //데이터 매니저 스크립트 참조 선언
    // Start is called before the first frame update
    void Start()
    {
        if(Managers.Status == null)
        {
            Debug.Log("Managers.Status가 null입니다.");
            return;
        }
        if (nextButton == null)
        { }
        else
        {
            iDay = Managers.Status.day;
            nextButton.onClick.AddListener(OnNextButtonClick);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //버튼 클릭시 호출되는 함수
    private void OnNextButtonClick()
    {
        if ((iDay < 7) && (iDay > 0))
        {
            Managers.Status.day = iDay + 1;
            //다음 씬으로 이동
            Managers.InGame.Init();
            SceneManager.LoadScene(sNextScene);
        }
        
        else if (iDay >= 7)
        {
            //해피 엔딩
            if(setEnding() == true)
            {
                SceneManager.LoadScene(sHappyEnding);
            }
            //배드 엔딩
            else
            {
                SceneManager.LoadScene(sBadEnding);
            }
        }
        else
        {
            Debug.Log("올바르지 않은 day");
            //에러 발생시 앱 강제 종료
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #endif
                        Application.Quit();
        }
    }
    private bool setEnding()
    {
        bool bIsHappyEnding = false;
        int iMoneyToPayLoan;
        int iLoan = 1000000;

        iMoneyToPayLoan = iLoan - Managers.Status.totalMoney;
        if(iMoneyToPayLoan > 0)
        {
            bIsHappyEnding = false;
        }
        else
        {
            bIsHappyEnding = true;
        }
        return bIsHappyEnding;
    }
}
