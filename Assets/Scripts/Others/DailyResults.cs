using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DailyResults : MonoBehaviour
{

    //텍스트 세팅
    public Text ResultText1;             //Result1 텍스트
    public Text ResultText2;             //Result2 텍스트
    public Text ResultText3;             //Result3 텍스트
    public Text ResultText4;             //Result4 텍스트
    public Text TotalGainText;           //오늘 얻은 돈&경험치 텍스트
    public Text CustomerSatisfiedResultText; //만족&불만족 손님 수 텍스트
    public Text RateText;                 //평점 텍스트

    public Text IngredientsCostText;    //재료비 텍스트
    public Text PartTimerPayText;       //알바 급여 텍스트
    public Text WastedFoodText;         //버린 음식값 텍스트;
    public Text TotalCostText;          //총 지출 계산 텍스트

    public Text GainText;               //손님들에게 얻은 것 목록 텍스트
    public Text EffectText;             //적용 효과 텍스트

    public Text loanText;               //대출 상환까지 남은 돈 텍스트
    public Text TotalMoneyText;         //총 소지금 텍스트


    //이 아래로 다른 스크립트에서 받아와야함
    public int iOfficerCount = 0;        //직장인 수
    public int iStudentCount = 0;       //대학생 수
    public int iProfessorCount = 0;     //교수님 수
    public int iObnoxiousCount = 0;     //진상 수

    //직장인, 대학생, 교수님, 진상 종류별 수익
    public int iOfficerIncome = 0;
    public int iStudentIncome = 0;
    public int iProfessorIncome = 0;
    public int iObnoxiousIncome = 0;

    //직장인, 대학생, 교수님, 진상 종류별 만족도 몇 증가 했는가
    public int iOfficerSatisfactionIncrease = 0;
    public int iStudentSatisfactionIncrease = 0;
    public int iProfessorSatisfactionIncrease = 0;
    public int iObnoxiousSatisfactionIncrease = 0;


    //직장인, 대학생, 교수님, 진상 종류별 만족도 현재 몇 레벨
    public int iOfficerSatisLevel = 0;
    public int iStudentSatisLevel = 0;
    public int iProfessorSatisLevel = 0;
    public int iObnoxiousSatisLevel = 0;

    //직장인, 대학생, 교수님, 진상 종류별 만족도 몇 레벨 증가했는가
    public int iOfficerSatisUpLv = 0;
    public int iStudentSatisUpLv = 0;
    public int iProfessorSatisUpLv = 0;
    public int iObnoxiousSatisUpLv = 0;

    //만족한 손님/불만족한 손님 몇 명
    public int iSatisfiedCustomers = 0;
    public int iUnsatisfiedCustomers = 0;

    //재료비
    public int iIngredientsCost = 0;
    //알바 급여
    public int iPartTimerPay = 0;
    //버린 음식으로 내야하는 돈
    public int iWastedFoodCost = 0;

    //이전일 소지금
    public int iPrevMoney = 0;


    public int iLoan= 1000000;                   //빚

    private int iDay = 0;                   //몇일차인지 기록

    private int iIncome = 0;                //총 얻은돈
    private int iTotalCost = 0;             //총 지출금
    private int fExpGet = 0;                //얻은 경험치

    private int iTotalMoney = 0;            //현재 총 소지금(기존 돈 + )
    private int iMoneyToPayLoan;            //현재 대출 상환까지 모아야하는 돈
    

    private DailyDataManager dataManager;       //스크립트 참조 선언


    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.FindObjectOfType<DailyDataManager>();
        setVals();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    
    //수익(지출 미반영) 반환 함수
    public int getIncome()
    {
        return iIncome;
    }

    //DailyDataManager에서 각 변수들 가져와서 사용
    private void setVals()
    {
        //임시: 타스크립트 가져와서 변수 설정
        this.iOfficerCount = dataManager.iOfficerCount;
        this.iStudentCount = dataManager.iStudentCount;
        this.iProfessorCount = dataManager.iProfessorCount;
        this.iObnoxiousCount = dataManager.iObnoxiousCount;

        this.iOfficerIncome = dataManager.iOfficerIncome;
        this.iStudentIncome = dataManager.iStudentIncome;
        this.iProfessorIncome = dataManager.iProfessorIncome;
        this.iObnoxiousIncome = dataManager.iObnoxiousIncome;

        this.iOfficerSatisfactionIncrease = dataManager.iOfficerSatisfactionIncrease;
        this.iStudentSatisfactionIncrease = dataManager.iStudentSatisfactionIncrease;
        this.iProfessorSatisfactionIncrease = dataManager.iProfessorSatisfactionIncrease;
        this.iObnoxiousSatisfactionIncrease = dataManager.iObnoxiousSatisfactionIncrease;

        this.iOfficerSatisLevel = dataManager.iOfficerSatisLevel;
        this.iStudentSatisLevel = dataManager.iStudentSatisLevel;
        this.iProfessorSatisLevel = dataManager.iProfessorSatisLevel;
        this.iObnoxiousSatisLevel = dataManager.iObnoxiousSatisLevel;

        this.iOfficerSatisUpLv = dataManager.iOfficerSatisUpLv;
        this.iStudentSatisUpLv = dataManager.iStudentSatisUpLv;
        this.iProfessorSatisUpLv = dataManager.iProfessorSatisUpLv;
        this.iObnoxiousSatisUpLv = dataManager.iObnoxiousSatisUpLv;

        this.iSatisfiedCustomers = dataManager.iSatisfiedCustomers;
        this.iUnsatisfiedCustomers = dataManager.iUnsatisfiedCustomers;

        this.iIngredientsCost = dataManager.iIngredientsCost;
        this.iPartTimerPay = dataManager.iPartTimerPay;
        this.iWastedFoodCost = dataManager.iWastedFoodCost;

        this.iPrevMoney = dataManager.iPrevMoney;
        this.iLoan = dataManager.iLoan;
        this.iDay = dataManager.iDay;

        //수익 계산
        calIncome();
        //지출 계산
        calCost();
        //경험치 계산
        calExp();
        //현재 소지금 계산
        calMoney();
        //남은 대출금 계산
        calLoan();



        //평점 세팅
        SetRate();
        //Text 세팅
        setTexts();
    }
    //수익 계산 함수
    private void calIncome()
    {
        iIncome = iOfficerIncome + iStudentIncome + iProfessorIncome + iObnoxiousIncome;
    }
    //지출 계산 함수
    private void calCost()
    {
        iTotalCost = iIngredientsCost + iPartTimerPay + iWastedFoodCost;
    }
    //경험치 계산 함수
    private void calExp()
    {
        fExpGet = iOfficerSatisfactionIncrease + iStudentSatisfactionIncrease + iProfessorSatisfactionIncrease + iObnoxiousSatisfactionIncrease;
    }
    //현재 소지금 계산 함수
    private void calMoney()
    {
        int iGap = iIncome - iTotalCost;
        this.iTotalMoney = iPrevMoney + iGap;
    }
    //남은 대출금 계산 함수
    private void calLoan()
    {
        this.iMoneyToPayLoan = iLoan - iTotalMoney;
    }
    //평점 세팅 함수
    private void SetRate()
    {
        //만족한 손님 수와 얻은 수익에 따라 그날그날 평가가 달라짐
        //임시: 수치는 나중에 바꿀 수 있게 변수 처리함

        //S급
        int iSscoreCustomer     = 60;
        int iSscoreIncome       = 250000;

        //A급
        int iAPlusscoreCustomer = 45;
        int iAscoreCustomer     = 40;
        int iAPlusscoreIncome   = 200000;
        int iAscoreIncome       = 180000;


        //B급
        int iBPlusscoreCustomer = 35;
        int iBscoreCustomer     = 30;
        int iBPlusscoreIncome   = 150000;
        int iBscoreIncome       = 130000;

        //C급
        int iCPlusscoreCustomer = 25;
        int iCscoreCustomer     = 20;
        int iCPlusscoreIncome   = 100000;
        int iCscoreIncome       = 800000;

        if ((iSatisfiedCustomers >= iSscoreCustomer) && (iIncome >= iSscoreIncome))
        {
            RateText.text = "S";
            RateText.color = Color.red;         //글씨 빨간색
            AddTextOutline(RateText, Color.black);
        }
        else if ((iSatisfiedCustomers >= iAPlusscoreCustomer) && (iIncome >= iAPlusscoreIncome))
        {
            RateText.text = "A+";
            RateText.color = Color.yellow;
            AddTextOutline(RateText, Color.black);
        }
        else if ((iSatisfiedCustomers >= iAscoreCustomer) && (iIncome >= iAscoreIncome))
        {
            RateText.text = "A";
            RateText.color = Color.yellow;
            AddTextOutline(RateText, Color.black);
        }
        else if ((iSatisfiedCustomers >= iBPlusscoreCustomer) && (iIncome >= iBPlusscoreIncome))
        {
            RateText.text = "B+";
            RateText.color = Color.green;
            AddTextOutline(RateText, Color.black);
        }
        else if ((iSatisfiedCustomers >= iBscoreCustomer) && (iIncome >= iBscoreIncome))
        {
            RateText.text = "B";
            RateText.color = Color.green;
            AddTextOutline(RateText, Color.black);
        }
        else if ((iSatisfiedCustomers >= iCPlusscoreCustomer) && (iIncome >= iCPlusscoreIncome))
        {
            RateText.text = "C+";
            RateText.color = Color.blue;
            AddTextOutline(RateText, Color.black);
        }
        else if ((iSatisfiedCustomers >= iCscoreCustomer) && (iIncome >= iCscoreIncome))
        {
            RateText.text = "C";
            RateText.color = Color.blue;
            AddTextOutline(RateText, Color.black);
        }
        else 
        {
            RateText.text = "D";
            RateText.color = Color.black;
            AddTextOutline(RateText, Color.black);
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


    //텍스트 세팅 함수
    private void setTexts()
    {
        setResultText();
        setTotalGainText();
        setCustomerSatisfiedText();
        setIngredientCostText();
        setPartTimerPayText();
        setWastedFoodCostText();
        setTotalCostText();
        setEarnedText();
        setEffectText();
        setMoneyLeftToPayText();
        setTotalMoney();
    }


    //ResultText
    private void setResultText()
    {
        ResultText1.text = string.Format
            (
                "직장인      x  {0}명: 수익 {1}원/만족도 {2} 증가/만족도 현재 {3}레벨({4} up)",
                iOfficerCount, iOfficerIncome, iOfficerSatisfactionIncrease, iOfficerSatisLevel, iOfficerSatisUpLv
            );
        ResultText1.text = string.Format
            (
                "대학생      x  {0}명: 수익 {1}원/만족도 {2} 증가/만족도 현재 {3}레벨({4} up)",
                iStudentCount, iStudentIncome, iStudentSatisfactionIncrease, iStudentSatisLevel, iStudentSatisUpLv
            );
        ResultText1.text = string.Format
            (
                "교수님      x  {0}명: 수익 {1}원/만족도 {2} 증가/만족도 현재 {3}레벨({4} up)",
                iProfessorCount, iProfessorIncome, iProfessorSatisfactionIncrease, iProfessorSatisLevel, iProfessorSatisUpLv
            );
        ResultText1.text = string.Format
            (
                "진  상      x  {0}명: 수익 {1}원/만족도 {2} 증가/만족도 현재 {3}레벨({4} up)",
                iObnoxiousCount, iObnoxiousIncome, iObnoxiousSatisfactionIncrease, iObnoxiousSatisLevel, iObnoxiousSatisUpLv
            );
    }
    //TotalGainText
    private void setTotalGainText()
    {
        TotalGainText.text = string.Format
        (
            "총 {0}원 획득/경험치 {1} 증가",
            iIncome, fExpGet
        );
    }
    //CustomerSatisFied
    private void setCustomerSatisfiedText()
    {
        CustomerSatisfiedResultText.text = string.Format
        (
            "만족한 손님     x {0}명\n" +
            "불만족한 손님     x {1}명",
            iSatisfiedCustomers, iUnsatisfiedCustomers
        );
    }
    //IngredientCost
    private void setIngredientCostText()
    {
        IngredientsCostText.text = string.Format
        (
            "재료비: -{0}원",
            iIngredientsCost
        );
    }
    //PartTimerPay
    private void setPartTimerPayText()
    {
        PartTimerPayText.text = string.Format
        (
            "알바 급여: -{0}원",
            iPartTimerPay
        );
    }
    //WastedFoodCost
    private void setWastedFoodCostText()
    {
        WastedFoodText.text = string.Format
        (
            "버린 음식: -{0}원",
            iWastedFoodCost
        );
    }
    private void setTotalCostText()
    {
        TotalCostText.text = string.Format
        (
            "총 {0}원 지출",
            iTotalCost
        );
    }

    //임시: 구현 조건, 레시피 등 도움
    private void setEarnedText()
    {
        
    }
    private void setEffectText()
    {
        EffectText.text = string.Format
        (
            ""
        //"적용 효과: \n" + 
        //임시: 구현 필요
        );
    }
    private void setMoneyLeftToPayText()
    {
        loanText.text = string.Format
        (
            "대출 상환까지 더 모아야 하는 돈: {0}원",
            iMoneyToPayLoan
        );
    }
    private void setTotalMoney()
    {
        TotalMoneyText.text = string.Format
        (
            "현재 총 소지금: {0}원",
            iTotalMoney
        );
    }
}