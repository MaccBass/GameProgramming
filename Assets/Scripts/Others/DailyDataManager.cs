using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Antlr3.Runtime.Tree.TreeWizard;

public class DailyDataManager : MonoBehaviour
{
    //이 아래로 다른 스크립트에서 받아와야함
    //직장인, 대학생, 교수님, 진상 몇 명 방문했는지 변수
    public int iOfficerCount= 0;        //직장인 수
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
    public int WastedFoodCost = 0;

    //임시: 스크립트 참조 선언 
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

    //    // 데이터 업데이트
    //    UpdateDataFromScripts();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //// 데이터를 다른 스크립트에서 가져오기
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

    //    //재료비, 알바 급여, 버린음식 비용 업데이트
    //    iIngredientsCost = script1.GetIngredientsCost();
    //    iPartTimerPay = script2.GetPartTimerPay();
    //    WastedFoodCost = script3.GetWastedFoodCost();
    //}
}