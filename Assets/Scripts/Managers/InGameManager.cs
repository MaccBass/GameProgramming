using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// InGameManager: 하루 영업 동안 사용되는 변수들로, 다음 일차로 넘어갈 때 전부 초기화되어야 함.
public class InGameManager
{
    // 그날 얻은 총 수익/만족도
    public int dailyTotalRevenue;
    public int dailyTotalCS;
    
    // 손님 타입 별 일일 수익금
    public Dictionary<string, int> DailyRevenue = new Dictionary<string, int>();
    // 손님 타입 별 일일 만족도
    public Dictionary<string, int> DailyCS = new Dictionary<string, int>();
    // 손님 타입 별 방문 숫자
    public Dictionary<string, int> DailyCount = new Dictionary<string, int>();

    // 만족/불만족한 손님 수
    public int isSatisfied;
    public int isDissatisfied;

    // 사전 준비 화면에서 소비한 총 돈
    public int shoppingCost;
    // 오늘 알바비
    public int wages;

    // 변수 초기화
    public void Init()
    {
        dailyTotalRevenue = 0;
        dailyTotalCS = 0;
        DailyCount.Clear();
        DailyRevenue.Clear();
        DailyCS.Clear();
        isSatisfied = 0;
        isDissatisfied = 0;
        shoppingCost = 0;
        wages = 0;
    }

    // 일일 정산 함수로, StatusManager 측 변수에 진행 상황을 저장함.
    public void Settlement()
    {
        foreach (int revenue in DailyRevenue.Values)
        {
            dailyTotalRevenue += revenue;
        }
        foreach (int cs in DailyCS.Values)
        {
            dailyTotalCS += cs;
        }
        Managers.Status.totalMoney += dailyTotalRevenue;
        Managers.Status.playerExp += dailyTotalCS;
        Managers.Status.LevelCheck();
        Managers.Status.totalMoney -= wages;
    }
    //손님 타입별 수 반환 함수
    public int getDailyCount(string customerType)
    {
        int iReturn = 0;
        if (DailyCount.ContainsKey(customerType))
        {
            iReturn = DailyCount[customerType];
        }
        return iReturn;
    }
    //손님 타입별 수익금 반환 함수
    public int getDailyRevenue(string customerType)
    {
        int iReturn = 0;
        if(DailyRevenue.ContainsKey(customerType))
        {
            iReturn = DailyRevenue[customerType];
        }
        return iReturn;
    }
    //손님 타입별 만족도 반환 함수
    public int getDailyCs(string customerType)
    {
        int iReturn = 0;
        if(DailyCS.ContainsKey(customerType))
        {
            iReturn = DailyCS[customerType];
        }
        return iReturn;
    }
    // 다음날 넘어갈 때 실행
    public void NextDay()
    {
        Init();
    }
    public void AddValues(string customerType, int payment, int cs)
    {
        Debug.Log("AddValues 실행됨.");
        if (DailyCount.ContainsKey(customerType))
        {
            DailyCount[customerType]++;
        }
        else
        {
            DailyCount.TryAdd(customerType, 1);
        }

        if (DailyCS.ContainsKey(customerType))
        {
            DailyCS[customerType]++;
        }
        else
        {
            DailyCS.TryAdd(customerType, cs);
        }

        if (DailyRevenue.ContainsKey(customerType))
        {
            DailyRevenue[customerType]++;
        }
        else
        {
            DailyRevenue.TryAdd(customerType, payment);
        }
    }
}
