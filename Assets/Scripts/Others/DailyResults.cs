using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DailyResults : MonoBehaviour
{

    //텍스트 세팅
    public Text ResultText1;             //Result1 텍스트
    public Text ResultText2;             //Result2 텍스트
    public Text ResultText3;             //Result3 텍스트
    public Text ResultText4;             //Result4 텍스트
    public Text TotalGainText;           //오늘 얻은 돈&경험치 텍스트
    public Text CustomerSatisfiedResultText; //만족&불만족 손님 수 텍스트
    public Text RateText;                //평점 텍스트

    public Text IngredientsCostText;    //재료비 텍스트
    public Text PartTimerPayText;       //알바 급여 텍스트
    public Text TotalCostText;          //총 지출 계산 텍스트

    public Text GainText;               //손님들에게 얻은 것 목록 텍스트
    private string currentGainText = "";

    public Text EffectText;             //적용 효과 텍스트
    public Text loanText;               //대출 상환까지 남은 돈 텍스트
    

    public Text TotalMoneyText;         //총 소지금 텍스트


    //이 아래로 다른 스크립트에서 받아와야함
    public int iOfficerCount = 0;       //직장인 수
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

    //만족한 손님/불만족한 손님 몇 명
    public int iSatisfiedCustomers;
    public int iDissatisfiedCustomers;

    //재료비
    public int iIngredientsCost;
    //알바 급여
    public int iPartTimerPay;

    //이전일 소지금
    public int iPrevMoney = 0;

    //플레이어 레벨 보상 플래그
    public bool bIsLv3RewardAwarded = false;
    public bool bIsLv5RewardAwarded = false;
    public bool bIsLv7RewardAwarded = false;
    public bool bIsLv9RewardAwarded = false;

    //인플루언서 관련 변수
    public bool bIsInfluSatisfied = false;          //인플루언서 만족 여부





    public int iLoan= 1000000;              //빚

    private int iDay;                   //몇일차인지 기록

    private int iIncome;                    //하루 얻은돈
    private int iTotalCost = 0;             //하루 지출금
    private int iExpGet;                //얻은 경험치
    public int iPlayerLv;               //플레이어 레벨
    public Recipe[] recipes;            


    private int iTotalMoney;            //현재 총 소지금(기존 돈 + )
    private int iMoneyToPayLoan = 0;        //현재 대출 상환까지 모아야하는 돈(대출금 - 현재 총 소지금)


    // Start is called before the first frame update
    void Start()
    {
        
        recipes = Resources.LoadAll<Recipe>("Recipes");
        currentGainText = "";
        
        setVals();
    }


    
    
    //수익(지출 미반영) 반환 함수
    public int getiMoneyToPayLoan()
    {
        return iMoneyToPayLoan;
    }
    public int getiDay()
    {
        return iDay;
    }

    //DailyDataManager에서 각 변수들 가져와서 사용
    private void setVals()
    {
        //임시: 진상은 작성 당시 설정되어 있지 않아서 Obnoxiout로 임시 설정함
        this.iOfficerCount = Managers.InGame.getDailyCount("Worker");
        this.iStudentCount = Managers.InGame.getDailyCount("Student");
        this.iProfessorCount = Managers.InGame.getDailyCount("Professor");
        this.iObnoxiousCount = Managers.InGame.getDailyCount("Obnoxious");

        this.iOfficerIncome = Managers.InGame.getDailyRevenue("Worker");
        this.iStudentIncome = Managers.InGame.getDailyRevenue("Student");
        this.iProfessorIncome = Managers.InGame.getDailyRevenue("Professor");
        this.iObnoxiousIncome = Managers.InGame.getDailyRevenue("Obnoxious");

        this.iOfficerSatisfactionIncrease = Managers.InGame.getDailyCs("Worker");
        this.iStudentSatisfactionIncrease = Managers.InGame.getDailyCs("Student");
        this.iProfessorSatisfactionIncrease = Managers.InGame.getDailyCs("Professor");
        this.iObnoxiousSatisfactionIncrease = Managers.InGame.getDailyCs("Obnoxious");

        this.iIncome = Managers.InGame.dailyTotalRevenue;
        this.iExpGet = Managers.InGame.dailyTotalCS;

        this.iSatisfiedCustomers = Managers.InGame.isSatisfied;
        this.iDissatisfiedCustomers = Managers.InGame.isDissatisfied;

        this.iIngredientsCost = Managers.InGame.shoppingCost;
        this.iPartTimerPay = Managers.InGame.wages;

        this.iPlayerLv = Managers.Status.playerLevel;
        //this.iPrevMoney = dataManager.iPrevMoney;
        this.iDay = Managers.Status.day;
        this.iTotalMoney = Managers.Status.totalMoney;


        //수익 계산
        calIncome();
        //지출 계산
        calCost();
        //경험치 계산
        //calExp();
        //현재 소지금 계산
        //calMoney();
        //남은 대출금 계산
        calLoan();



        //평점 세팅
        SetRate();
        //Text 세팅
        setTexts();
    }
    //수익 계산 함수 - 안 씀
    private void calIncome()
    {
        if(bIsInfluSatisfied == true)
        {
            //iTotalMoney는 이미 오늘의 수익금이 더해진 상태로 로딩되기 때문에 인플루언서 부가 효과는 iIncome을 한 번만 더 더하도록 함
            iTotalMoney = iTotalMoney + iIncome;
            setEffectText();
            bIsInfluSatisfied = false;
        }
        
    }
    //지출 계산 함수
    private void calCost()
    {
        iTotalCost = iIngredientsCost + iPartTimerPay;
    }
    //경험치 계산 함수 - 안 씀
    private void calExp()
    {
        iExpGet = iOfficerSatisfactionIncrease + iStudentSatisfactionIncrease + iProfessorSatisfactionIncrease + iObnoxiousSatisfactionIncrease;
    }
    //현재 소지금 계산 함수 - 안 씀
    private void calMoney()
    {
        int iGap = iIncome - iTotalCost;
        this.iTotalMoney = iPrevMoney + iGap;
    }
    //남은 대출금 계산 함수
    private void calLoan()
    {
        this.iMoneyToPayLoan = iLoan - iTotalMoney;
        if(iMoneyToPayLoan < 0)
        {
            iMoneyToPayLoan = 0;
        }
        else
        {}
    }
    //평점 세팅 함수
    private void SetRate()
    {
        //만족한 손님 수와 얻은 수익에 따라 그날그날 평가가 달라짐
        //임시: 수치는 나중에 바꿀 수 있게 변수 처리함

        //S
        int iSscoreCustomer     = 60;
        int iSscoreIncome       = 250000;

        //A
        int iAPlusscoreCustomer = 45;
        int iAscoreCustomer     = 40;
        int iAPlusscoreIncome   = 200000;
        int iAscoreIncome       = 180000;


        //B
        int iBPlusscoreCustomer = 35;
        int iBscoreCustomer     = 30;
        int iBPlusscoreIncome   = 150000;
        int iBscoreIncome       = 130000;

        //C
        int iCPlusscoreCustomer = 25;
        int iCscoreCustomer     = 20;
        int iCPlusscoreIncome   = 100000;
        int iCscoreIncome       = 800000;

        if ((iSatisfiedCustomers >= iSscoreCustomer) && (iIncome >= iSscoreIncome))
        {
            RateText.text = "S";
            RateText.color = Color.red;         
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
        setTotalCostText();
        setEarnedText();
        setMoneyLeftToPayText();
        setTotalMoney();
    }


    //ResultText
    private void setResultText()
    {
        ResultText1.text = $"직장인      x  {iOfficerCount}명: 수익 {iOfficerIncome}원/만족도 {iOfficerSatisfactionIncrease} 증가";
        ResultText2.text = $"대학생      x  {iStudentCount}명: 수익 {iStudentIncome}원/만족도 {iStudentSatisfactionIncrease} 증가";
        ResultText3.text = $"교수님      x  {iProfessorCount}명: 수익 {iProfessorIncome}원/만족도 {iProfessorSatisfactionIncrease} 증가";
        ResultText4.text = $"진  상      x  {iObnoxiousCount}명: 수익 {iObnoxiousIncome}원/만족도 {iObnoxiousSatisfactionIncrease} 증가";
    }
    //TotalGainText
    private void setTotalGainText()
    {
        TotalGainText.text = $"총 {iIncome}원 획득/경험치 {iExpGet} 증가";
    }
    //CustomerSatisFied
    private void setCustomerSatisfiedText()
    {
        CustomerSatisfiedResultText.text = $"만족한 손님     x {iSatisfiedCustomers}명\n불만족한 손님     x {iDissatisfiedCustomers}명";
    }
    //IngredientCost
    private void setIngredientCostText()
    {
        IngredientsCostText.text = $"재료비: -{iIngredientsCost}원";
    }

    public void giveLvAwards()
    {

        if((iPlayerLv >= 3) && (bIsLv3RewardAwarded == false))
        {
            AddTextLine("레벨 3 달성 보상: 라면 레시피");
            UnlockRecipe("라면");
            bIsLv3RewardAwarded = true;
        }
        if ((iPlayerLv >= 5) && (bIsLv5RewardAwarded == false))
        {
            AddTextLine("레벨 5 달성 보상: 윙봉 레시피");
            UnlockRecipe("윙봉");
            bIsLv5RewardAwarded = true;
        }
        if ((iPlayerLv >= 7) && (bIsLv7RewardAwarded == false))
        {
            AddTextLine("레벨 7 달성 보상: 두부김치 레시피");
            UnlockRecipe("두부김치");
            bIsLv7RewardAwarded = true;
        }
        if ((iPlayerLv >= 9) && (bIsLv9RewardAwarded == false))
        {
            AddTextLine("레벨 9 달성 보상: 피자 레시피");
            UnlockRecipe("피자");
            bIsLv9RewardAwarded = true;
        }
    }

    private void AddTextLine(string content)
    {
        if(string.IsNullOrEmpty(content))
        {
        }
        else
        {
            currentGainText = currentGainText + "\n";
        }
        currentGainText = currentGainText + content;
        UpdateGainTextUI();
    }
    private void UpdateGainTextUI()
    {
        if(GainText != null)
        {
            GainText.text = currentGainText;
        }
        else
        {
            Debug.Log("GainText가 할당되지 않음");
        }
    }

    //PartTimerPay
    private void setPartTimerPayText()
    {
        PartTimerPayText.text = $"알바 급여: -{iPartTimerPay}원";
    }
    
    private void setTotalCostText()
    {
        TotalCostText.text = $"총 {0}원 지출";
    }

    private void setEarnedText()
    {
        giveLvAwards();
    }
    private void UnlockRecipe(string recipeName)
    {
        foreach (var recipe in recipes)
        {
            if(recipe.itemName == recipeName)
            {
                recipe.isObtained = true;
            }
        }
    }
    private void setEffectText()
    {
        EffectText.text = "오늘 수익금 두배!";
    }
    private void setMoneyLeftToPayText()
    {
        loanText.text = $"대출 상환까지 더 모아야 하는 돈: {iMoneyToPayLoan}원";
    }
    private void setTotalMoney()
    {
        TotalMoneyText.text = $"현재 총 소지금: {iTotalMoney}원";
    }
}