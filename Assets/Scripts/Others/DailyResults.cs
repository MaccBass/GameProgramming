using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyResults : MonoBehaviour
{

    //�ؽ�Ʈ ����
    public Text ResultText;             //Result �ؽ�Ʈ
    public Text TotalGainText;          //���� ���� ��&����ġ �ؽ�Ʈ
    public Text CustomerSatisfiedResultText; //����&�Ҹ��� �մ� �� �ؽ�Ʈ
    public Text RateText;               //���� �ؽ�Ʈ

    public Text IngredientsCostText;    //���� �ؽ�Ʈ
    public Text PartTimerPayText;       //�˹� �޿� �ؽ�Ʈ
    public Text WastedFoodText;         //���� ���İ� �ؽ�Ʈ;
    public Text TotalSpendText;         //�� ���� ��� �ؽ�Ʈ

    public Text GainText;               //�մԵ鿡�� ���� �� ��� �ؽ�Ʈ
    public Text EffectText;             //���� ȿ�� �ؽ�Ʈ

    public Text loanText;               //���� ��ȯ���� ���� �� �ؽ�Ʈ
    public Text TotalMoneyText;         //�� ������ �ؽ�Ʈ

    public Button nextButton;           //�������� �Ѿ�� ��ư


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
    public int iPrevMoney;


    public int iLoan;                   //��

    private int iDay;                   //���������� ���

    private int iIncome;                //�� ������
    private int iTotalCost;             //�� �����
    private int fExpGet;                //���� ����ġ

    private int iTotalMoney;            //���� �� ������(���� �� + )
    private int iMoneyToPayLoan;        //���� ���� ��ȯ���� ��ƾ��ϴ� ��
    

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

    //Rate(����) �ؽ�Ʈ �� ���� �Լ�
    public void SetRateText()
    {
        if (RateText == null)
        {
            return;
        }
        //Rate �ؽ�Ʈ ���� �� �� ����
        else
        {
            string sRate = RateText.text;
            switch(sRate)
            {
                case "S":
                    RateText.color = Color.red;         //�۾� ������
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
    
    //����(���� �̹ݿ�) ��ȯ �Լ�
    public int getIncome()
    {
        return iIncome;
    }

    //DailyDataManager���� �� ������ �����ͼ� ���
    private void setVals()
    {
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



    //�ؽ�Ʈ ���� �Լ�

    //ResultTest1
    private void setResultText1()
    {

    }
    
}
