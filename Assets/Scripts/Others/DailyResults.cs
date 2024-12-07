using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DailyResults : MonoBehaviour
{

    //�ؽ�Ʈ ����
    public Text ResultText1;             //Result1 �ؽ�Ʈ
    public Text ResultText2;             //Result2 �ؽ�Ʈ
    public Text ResultText3;             //Result3 �ؽ�Ʈ
    public Text ResultText4;             //Result4 �ؽ�Ʈ
    public Text TotalGainText;           //���� ���� ��&����ġ �ؽ�Ʈ
    public Text CustomerSatisfiedResultText; //����&�Ҹ��� �մ� �� �ؽ�Ʈ
    public Text RateText;                 //���� �ؽ�Ʈ

    public Text IngredientsCostText;    //���� �ؽ�Ʈ
    public Text PartTimerPayText;       //�˹� �޿� �ؽ�Ʈ
    public Text WastedFoodText;         //���� ���İ� �ؽ�Ʈ;
    public Text TotalCostText;          //�� ���� ��� �ؽ�Ʈ

    public Text GainText;               //�մԵ鿡�� ���� �� ��� �ؽ�Ʈ
    public Text EffectText;             //���� ȿ�� �ؽ�Ʈ

    public Text loanText;               //���� ��ȯ���� ���� �� �ؽ�Ʈ
    public Text TotalMoneyText;         //�� ������ �ؽ�Ʈ


    //�� �Ʒ��� �ٸ� ��ũ��Ʈ���� �޾ƿ;���
    public int iOfficerCount = 0;        //������ ��
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


    //������, ���л�, ������, ���� ������ ������ ���� �� ����
    public int iOfficerSatisLevel = 0;
    public int iStudentSatisLevel = 0;
    public int iProfessorSatisLevel = 0;
    public int iObnoxiousSatisLevel = 0;

    //������, ���л�, ������, ���� ������ ������ �� ���� �����ߴ°�
    public int iOfficerSatisUpLv = 0;
    public int iStudentSatisUpLv = 0;
    public int iProfessorSatisUpLv = 0;
    public int iObnoxiousSatisUpLv = 0;

    //������ �մ�/�Ҹ����� �մ� �� ��
    public int iSatisfiedCustomers = 0;
    public int iUnsatisfiedCustomers = 0;

    //����
    public int iIngredientsCost = 0;
    //�˹� �޿�
    public int iPartTimerPay = 0;
    //���� �������� �����ϴ� ��
    public int iWastedFoodCost = 0;

    //������ ������
    public int iPrevMoney = 0;


    public int iLoan= 1000000;                   //��

    private int iDay = 0;                   //���������� ���

    private int iIncome = 0;                //�� ������
    private int iTotalCost = 0;             //�� �����
    private int fExpGet = 0;                //���� ����ġ

    private int iTotalMoney = 0;            //���� �� ������(���� �� + )
    private int iMoneyToPayLoan;            //���� ���� ��ȯ���� ��ƾ��ϴ� ��
    

    private DailyDataManager dataManager;       //��ũ��Ʈ ���� ����


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

    
    
    //����(���� �̹ݿ�) ��ȯ �Լ�
    public int getIncome()
    {
        return iIncome;
    }

    //DailyDataManager���� �� ������ �����ͼ� ���
    private void setVals()
    {
        //�ӽ�: Ÿ��ũ��Ʈ �����ͼ� ���� ����
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

        //���� ���
        calIncome();
        //���� ���
        calCost();
        //����ġ ���
        calExp();
        //���� ������ ���
        calMoney();
        //���� ����� ���
        calLoan();



        //���� ����
        SetRate();
        //Text ����
        setTexts();
    }
    //���� ��� �Լ�
    private void calIncome()
    {
        iIncome = iOfficerIncome + iStudentIncome + iProfessorIncome + iObnoxiousIncome;
    }
    //���� ��� �Լ�
    private void calCost()
    {
        iTotalCost = iIngredientsCost + iPartTimerPay + iWastedFoodCost;
    }
    //����ġ ��� �Լ�
    private void calExp()
    {
        fExpGet = iOfficerSatisfactionIncrease + iStudentSatisfactionIncrease + iProfessorSatisfactionIncrease + iObnoxiousSatisfactionIncrease;
    }
    //���� ������ ��� �Լ�
    private void calMoney()
    {
        int iGap = iIncome - iTotalCost;
        this.iTotalMoney = iPrevMoney + iGap;
    }
    //���� ����� ��� �Լ�
    private void calLoan()
    {
        this.iMoneyToPayLoan = iLoan - iTotalMoney;
    }
    //���� ���� �Լ�
    private void SetRate()
    {
        //������ �մ� ���� ���� ���Ϳ� ���� �׳��׳� �򰡰� �޶���
        //�ӽ�: ��ġ�� ���߿� �ٲ� �� �ְ� ���� ó����

        //S��
        int iSscoreCustomer     = 60;
        int iSscoreIncome       = 250000;

        //A��
        int iAPlusscoreCustomer = 45;
        int iAscoreCustomer     = 40;
        int iAPlusscoreIncome   = 200000;
        int iAscoreIncome       = 180000;


        //B��
        int iBPlusscoreCustomer = 35;
        int iBscoreCustomer     = 30;
        int iBPlusscoreIncome   = 150000;
        int iBscoreIncome       = 130000;

        //C��
        int iCPlusscoreCustomer = 25;
        int iCscoreCustomer     = 20;
        int iCPlusscoreIncome   = 100000;
        int iCscoreIncome       = 800000;

        if ((iSatisfiedCustomers >= iSscoreCustomer) && (iIncome >= iSscoreIncome))
        {
            RateText.text = "S";
            RateText.color = Color.red;         //�۾� ������
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
                "������      x  {0}��: ���� {1}��/������ {2} ����/������ ���� {3}����({4} up)",
                iOfficerCount, iOfficerIncome, iOfficerSatisfactionIncrease, iOfficerSatisLevel, iOfficerSatisUpLv
            );
        ResultText1.text = string.Format
            (
                "���л�      x  {0}��: ���� {1}��/������ {2} ����/������ ���� {3}����({4} up)",
                iStudentCount, iStudentIncome, iStudentSatisfactionIncrease, iStudentSatisLevel, iStudentSatisUpLv
            );
        ResultText1.text = string.Format
            (
                "������      x  {0}��: ���� {1}��/������ {2} ����/������ ���� {3}����({4} up)",
                iProfessorCount, iProfessorIncome, iProfessorSatisfactionIncrease, iProfessorSatisLevel, iProfessorSatisUpLv
            );
        ResultText1.text = string.Format
            (
                "��  ��      x  {0}��: ���� {1}��/������ {2} ����/������ ���� {3}����({4} up)",
                iObnoxiousCount, iObnoxiousIncome, iObnoxiousSatisfactionIncrease, iObnoxiousSatisLevel, iObnoxiousSatisUpLv
            );
    }
    //TotalGainText
    private void setTotalGainText()
    {
        TotalGainText.text = string.Format
        (
            "�� {0}�� ȹ��/����ġ {1} ����",
            iIncome, fExpGet
        );
    }
    //CustomerSatisFied
    private void setCustomerSatisfiedText()
    {
        CustomerSatisfiedResultText.text = string.Format
        (
            "������ �մ�     x {0}��\n" +
            "�Ҹ����� �մ�     x {1}��",
            iSatisfiedCustomers, iUnsatisfiedCustomers
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
    //PartTimerPay
    private void setPartTimerPayText()
    {
        PartTimerPayText.text = string.Format
        (
            "�˹� �޿�: -{0}��",
            iPartTimerPay
        );
    }
    //WastedFoodCost
    private void setWastedFoodCostText()
    {
        WastedFoodText.text = string.Format
        (
            "���� ����: -{0}��",
            iWastedFoodCost
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

    //�ӽ�: ���� ����, ������ �� ����
    private void setEarnedText()
    {
        
    }
    private void setEffectText()
    {
        EffectText.text = string.Format
        (
            ""
        //"���� ȿ��: \n" + 
        //�ӽ�: ���� �ʿ�
        );
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