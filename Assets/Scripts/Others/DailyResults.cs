using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DailyResults : MonoBehaviour
{

    //�ؽ�Ʈ ����
    public Text ResultText1;             //Result1 �ؽ�Ʈ
    public Text ResultText2;             //Result2 �ؽ�Ʈ
    public Text ResultText3;             //Result3 �ؽ�Ʈ
    public Text ResultText4;             //Result4 �ؽ�Ʈ
    public Text TotalGainText;           //���� ���� ��&����ġ �ؽ�Ʈ
    public Text CustomerSatisfiedResultText; //����&�Ҹ��� �մ� �� �ؽ�Ʈ
    public Text RateText;                //���� �ؽ�Ʈ

    public Text IngredientsCostText;    //���� �ؽ�Ʈ
    public Text PartTimerPayText;       //�˹� �޿� �ؽ�Ʈ
    public Text TotalCostText;          //�� ���� ��� �ؽ�Ʈ

    public Text GainText;               //�մԵ鿡�� ���� �� ��� �ؽ�Ʈ
    private string currentGainText = "";

    public Text EffectText;             //���� ȿ�� �ؽ�Ʈ
    public Text loanText;               //���� ��ȯ���� ���� �� �ؽ�Ʈ
    

    public Text TotalMoneyText;         //�� ������ �ؽ�Ʈ


    //�� �Ʒ��� �ٸ� ��ũ��Ʈ���� �޾ƿ;���
    public int iOfficerCount = 0;       //������ ��
    public int iStudentCount = 0;       //���л� ��
    public int iProfessorCount = 0;     //������ ��
    public int iObnoxiousCount = 0;     //���� ��

    //������, ���л�, ������, ���� ������ ����
    public int iOfficerIncome = 0;
    public int iStudentIncome = 0;
    public int iProfessorIncome = 0;
    public int iObnoxiousIncome = 0;

    //������, ���л�, ������, ���� ������ ������ �� ���� �ߴ°�
    public int iOfficerSatisfactionIncrease = 0;
    public int iStudentSatisfactionIncrease = 0;
    public int iProfessorSatisfactionIncrease = 0;
    public int iObnoxiousSatisfactionIncrease = 0;

    //������ �մ�/�Ҹ����� �մ� �� ��
    public int iSatisfiedCustomers;
    public int iDissatisfiedCustomers;

    //����
    public int iIngredientsCost;
    //�˹� �޿�
    public int iPartTimerPay;

    //������ ������
    public int iPrevMoney = 0;

    //�÷��̾� ���� ���� �÷���
    public bool bIsLv3RewardAwarded = false;
    public bool bIsLv5RewardAwarded = false;
    public bool bIsLv7RewardAwarded = false;
    public bool bIsLv9RewardAwarded = false;

    //���÷�� ���� ����
    public bool bIsInfluSatisfied = false;          //���÷�� ���� ����





    public int iLoan= 1000000;              //��

    private int iDay;                   //���������� ���

    private int iIncome;                    //�Ϸ� ������
    private int iTotalCost = 0;             //�Ϸ� �����
    private int iExpGet;                //���� ����ġ
    public int iPlayerLv;               //�÷��̾� ����
    public Recipe[] recipes;            


    private int iTotalMoney;            //���� �� ������(���� �� + )
    private int iMoneyToPayLoan = 0;        //���� ���� ��ȯ���� ��ƾ��ϴ� ��(����� - ���� �� ������)
    

    private DailyDataManager dataManager;       //��ũ��Ʈ ���� ����


    // Start is called before the first frame update
    void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipes");
        currentGainText = "";
        dataManager = GameObject.FindObjectOfType<DailyDataManager>();
        setVals();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    
    //����(���� �̹ݿ�) ��ȯ �Լ�
    public int getiMoneyToPayLoan()
    {
        return iMoneyToPayLoan;
    }
    public int getiDay()
    {
        return iDay;
    }

    //DailyDataManager���� �� ������ �����ͼ� ���
    private void setVals()
    {
        
        //�ӽ�: Ÿ��ũ��Ʈ �����ͼ� ���� ����
        //�ӽ�: DataManager�� error�� �����ϱ� ���� ���� �ӽ� ��ũ��Ʈ�̹Ƿ� ��� ������ ������ �ڿ��� ����
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


        //���� ���
        calIncome();
        //���� ���
        calCost();
        //����ġ ���
        //calExp();
        //���� ������ ���
        //calMoney();
        //���� ����� ���
        calLoan();



        //���� ����
        SetRate();
        //Text ����
        setTexts();
    }
    //���� ��� �Լ� - �� ��
    private void calIncome()
    {
        if(bIsInfluSatisfied == true)
        {
            //iTotalMoney�� �̹� ������ ���ͱ��� ������ ���·� �ε��Ǳ� ������ ���÷�� �ΰ� ȿ���� iIncome�� �� ���� �� ���ϵ��� ��
            iTotalMoney = iTotalMoney + iIncome;
            setEffectText();
            bIsInfluSatisfied = false;
        }
        
    }
    //���� ��� �Լ�
    private void calCost()
    {
        iTotalCost = iIngredientsCost + iPartTimerPay;
    }
    //����ġ ��� �Լ� - �� ��
    private void calExp()
    {
        iExpGet = iOfficerSatisfactionIncrease + iStudentSatisfactionIncrease + iProfessorSatisfactionIncrease + iObnoxiousSatisfactionIncrease;
    }
    //���� ������ ��� �Լ� - �� ��
    private void calMoney()
    {
        int iGap = iIncome - iTotalCost;
        this.iTotalMoney = iPrevMoney + iGap;
    }
    //���� ����� ��� �Լ�
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
    //���� ���� �Լ�
    private void SetRate()
    {
        //������ �մ� ���� ���� ���Ϳ� ���� �׳��׳� �򰡰� �޶���
        //�ӽ�: ��ġ�� ���߿� �ٲ� �� �ְ� ���� ó����

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
    //Rate(����) �ؽ�Ʈ �ܰ��� �� ���� �Լ�
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


    //�ؽ�Ʈ ���� �Լ�
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
        ResultText1.text = string.Format
            (
                "������      x  {0}��: ���� {1}��/������ {2} ����",
                iOfficerCount, iOfficerIncome, iOfficerSatisfactionIncrease
            );
        ResultText1.text = string.Format
            (
                "���л�      x  {0}��: ���� {1}��/������ {2} ����",
                iStudentCount, iStudentIncome, iStudentSatisfactionIncrease
            );
        ResultText1.text = string.Format
            (
                "������      x  {0}��: ���� {1}��/������ {2} ����",
                iProfessorCount, iProfessorIncome, iProfessorSatisfactionIncrease
            );
        ResultText1.text = string.Format
            (
                "��  ��      x  {0}��: ���� {1}��/������ {2} ����",
                iObnoxiousCount, iObnoxiousIncome, iObnoxiousSatisfactionIncrease
            );
    }
    //TotalGainText
    private void setTotalGainText()
    {
        TotalGainText.text = string.Format
        (
            "�� {0}�� ȹ��/����ġ {1} ����",
            iIncome, iExpGet
        );
    }
    //CustomerSatisFied
    private void setCustomerSatisfiedText()
    {
        CustomerSatisfiedResultText.text = string.Format
        (
            "������ �մ�     x {0}��\n" +
            "�Ҹ����� �մ�     x {1}��",
            iSatisfiedCustomers, iDissatisfiedCustomers
        );
    }
    //IngredientCost
    private void setIngredientCostText()
    {
        IngredientsCostText.text = string.Format
        (
            "����: -{0}��",
            iIngredientsCost
        );
    }

    public void giveLvAwards()
    {

        if((iPlayerLv >= 3) && (bIsLv3RewardAwarded == false))
        {
            AddTextLine("���� 3 �޼� ����: ��� ������");
            UnlockRecipe("���");
            bIsLv3RewardAwarded = true;
        }
        if ((iPlayerLv >= 5) && (bIsLv5RewardAwarded == false))
        {
            AddTextLine("���� 5 �޼� ����: ���� ������");
            UnlockRecipe("����");
            bIsLv5RewardAwarded = true;
        }
        if ((iPlayerLv >= 7) && (bIsLv7RewardAwarded == false))
        {
            AddTextLine("���� 7 �޼� ����: �κα�ġ ������");
            UnlockRecipe("�κα�ġ");
            bIsLv7RewardAwarded = true;
        }
        if ((iPlayerLv >= 9) && (bIsLv9RewardAwarded == false))
        {
            AddTextLine("���� 9 �޼� ����: ���� ������");
            UnlockRecipe("����");
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
            Debug.Log("GainText�� �Ҵ���� ����");
        }
    }

    //PartTimerPay
    private void setPartTimerPayText()
    {
        PartTimerPayText.text = string.Format
        (
            "�˹� �޿�: -{0}��",
            iPartTimerPay
        );
    }
    
    private void setTotalCostText()
    {
        TotalCostText.text = string.Format
        (
            "�� {0}�� ����",
            iTotalCost
        );
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
        EffectText.text = "���� ���ͱ� �ι�!";
    }
    private void setMoneyLeftToPayText()
    {
        loanText.text = string.Format
        (
            "���� ��ȯ���� �� ��ƾ� �ϴ� ��: {0}��",
            iMoneyToPayLoan
        );
    }
    private void setTotalMoney()
    {
        TotalMoneyText.text = string.Format
        (
            "���� �� ������: {0}��",
            iTotalMoney
        );
    }
}