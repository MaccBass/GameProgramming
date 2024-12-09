using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour
{
    public Button nextButton;           //다음날로 넘어가는 버튼
    public string sNextScene = "Open_Customer";            //임시: 다음 씬 이름 지정하기
    private string sHappyEnding = "2. HappyEnding CutScene";    //해피 엔딩 컷씬
    private string sBadEnding = "3. BadEnding CutScene";        //배드 엔딩 컷씬

    private int iDay;                   //일차 변수
    private int iMoneyToPayLoan;
    private DailyResults dailyResults;                  //데이터 매니저 스크립트 참조 선언
    // Start is called before the first frame update
    void Start()
    {
        if (nextButton == null)
        { }
        else
        {
            iDay = dailyResults.getiDay();
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
            //다음 씬으로 이동
            SceneManager.LoadScene(sNextScene);
        }
        //임시. day count를 1부터 시작할건지 0부터 시작할건지 확인 필요. 일단 1부터 시작한다고 가정하고 작성함
        else if (iDay > 7)
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
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
    private bool setEnding()
    {
        bool bIsHappyEnding = false;
        iMoneyToPayLoan = dailyResults.getiMoneyToPayLoan();
        if (iMoneyToPayLoan > 0)
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
