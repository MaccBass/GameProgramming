using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyResults : MonoBehaviour
{

    //텍스트 세팅
    public Text ResultText;             //Result 텍스트
    public Text TotalGainText;          //오늘 얻은 돈&경험치 텍스트
    public Text CustomerSatisfiedResultText; //만족&불만족 손님 수 텍스트
    public Text RateText;               //평점 텍스트

    public Text IngredientsCostText;    //재료비 텍스트
    public Text PartTimerPayText;       //알바 급여 텍스트
    public Text WastedFoodText;         //버린 음식값 텍스트;
    public Text TotalSpendText;         //총 지출 계산 텍스트

    public Text GainText;               //손님들에게 얻은 것 목록 텍스트
    public Text EffectText;             //적용 효과 텍스트

    public Text loanText;               //대출 상환까지 남은 돈 텍스트
    public Text TotalMoneyText;         //총 소지금 텍스트

    public Button nextButton;           //다음날로 넘어가는 버튼


    //이 아래로 다른 스크립트에서 받아와야함
    //직장인, 대학생, 교수님, 진상 몇 명 방문했는지 변수

    //직장인, 대학생, 교수님, 진상 종류별 수익


    //직장인, 대학생, 교수님, 진상 종류별 만족도 몇 증가 했는가



    //직장인, 대학생, 교수님, 진상 종류별 만족도 현재 몇 레벨

    //직장인, 대학생, 교수님, 진상 종류별 만족도 몇 레벨 증가했는가

    //만족한 손님/불만족한 손님 몇 명

    //재료비

    //알바 급여

    //버린 음식으로 내야하는 돈


    private int iDay;                   //몇일차인지 기록

    private int iIncome;                //총 얻은돈
    private int iTotalCost;             //총 지출금
    private int fExpGet;              //얻은 경험치
    
    private int iMoneyToPayLoan;        //현재 대출 상환까지 모아야하는 돈
    private int iTotalMoney;            //현재 총 소지금(기존 돈 + )


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Rate(평점) 텍스트 색 지정 함수
    public void SetRateText()
    {
        if (RateText == null)
        {
            return;
        }
        //Rate 텍스트 설정 및 색 설정
        else
        {
            string sRate = RateText.text;
            switch(sRate)
            {
                case "S":
                    RateText.color = Color.red;         //글씨 빨간색
                    AddTextOutline(RateText, Color.black);
                    break;
                case "A+": case "A":
                    RateText.color = Color.yellow;
                    AddTextOutline(RateText, Color.black);
                    break;
                case "B+": case "B":
                    RateText.color = Color.green;
                    AddTextOutline(RateText, Color.black);
                    break;
                case "C+": case "C":
                    RateText.color = Color.blue;
                    AddTextOutline(RateText, Color.black);
                    break;
                default:
                    RateText.color = Color.black;
                    AddTextOutline(RateText, Color.black);
                    break;
            }
        }
    }
    //Rate(평점) 텍스트 외곽선 색 지정 함수
    private void AddTextOutline(Text text, Color outlineColor)
    {
        Outline outline = text.GetComponent<Outline>();
        if (outline == null)
        {
            outline = text.gameObject.AddComponent<Outline>();
        }
        outline.effectColor = outlineColor;
        outline.effectDistance = new Vector2(1.5f, -1.5f);
    }
    
    //수익(지출 미반영) 반환 함수
    public int getIncome()
    {
        return iIncome;
    }
    
}
