using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

public class DailyDataManager : MonoBehaviour
{
    //�� �Ʒ��� �ٸ� ��ũ��Ʈ���� �޾ƿ;���
    //������, ���л�, ������, ���� �� �� �湮�ߴ��� ����
    public int iOfficerCount= 0;        //������ ��
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
    public int WastedFoodCost = 0;

    //�ӽ�: ��ũ��Ʈ ���� ���� 
    //private OtherScript1 script1;
    //private OtherScript2 script2;
    //private OtherScript3 script3;




    //void Start()
    //{
    //    script1 = GameObject.FindObjectOfType<OtherScript1>();
    //    script2 = GameObject.FindObjectOfType<OtherScript2>();
    //    script3 = GameObject.FindObjectOfType<OtherScript3>();
    //    if (script1 == null || script2 == null || script3 == null)
    //    {

    //    }

    //    // ������ ������Ʈ
    //    UpdateDataFromScripts();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //// �����͸� �ٸ� ��ũ��Ʈ���� ��������
    //void UpdateDataFromScripts()
    //{
    //    if (script1 == null)
    //    { }
    //    else
    //    {
    //        iOfficerCount = script1.GetOfficerCount();
    //        iOfficerIncome = script1.GetOfficerIncome();
    //        iOfficerSatisfactionIncrease = script1.GetOfficerSatisfactionIncrease();
    //    }

    //    if (script2 == null)
    //    { }
    //    else
    //    {
    //        iStudentCount = script2.GetStudentCount();
    //        iStudentIncome = script2.GetStudentIncome();
    //        iStudentSatisfactionIncrease = script2.GetStudentSatisfactionIncrease();
    //    }


    //    if (script3 == null)
    //    { }
    //    else
    //    {
    //        iProfessorCount = script3.GetProfessorCount();
    //        iProfessorIncome = script3.GetProfessorIncome();
    //        iProfessorSatisfactionIncrease = script3.GetProfessorSatisfactionIncrease();
    //    }

    //    //����, �˹� �޿�, �������� ��� ������Ʈ
    //    iIngredientsCost = script1.GetIngredientsCost();
    //    iPartTimerPay = script2.GetPartTimerPay();
    //    WastedFoodCost = script3.GetWastedFoodCost();
    //}
}