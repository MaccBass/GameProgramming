using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// InGameManager: �Ϸ� ���� ���� ���Ǵ� �������, ���� ������ �Ѿ �� ���� �ʱ�ȭ�Ǿ�� ��.
public class InGameManager
{
    // �׳� ���� �� ����/������
    public int dailyTotalRevenue;
    public int dailyTotalCS;
    
    // �մ� Ÿ�� �� ���� ���ͱ�
    public Dictionary<string, int> DailyRevenue = new Dictionary<string, int>();
    // �մ� Ÿ�� �� ���� ������
    public Dictionary<string, int> DailyCS = new Dictionary<string, int>();
    // �մ� Ÿ�� �� �湮 ����
    public Dictionary<string, int> DailyCount = new Dictionary<string, int>();

    // ����/�Ҹ����� �մ� ��
    public int isSatisfied;
    public int isDissatisfied;

    // ���� �غ� ȭ�鿡�� �Һ��� �� ��
    public int shoppingCost;
    // ���� �˹ٺ�
    public int wages;

    // ���� �ʱ�ȭ
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

    // ���� ���� �Լ���, StatusManager �� ������ ���� ��Ȳ�� ������.
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
    //�մ� Ÿ�Ժ� �� ��ȯ �Լ�
    public int getDailyCount(string customerType)
    {
        int iReturn = 0;
        if (DailyCount.ContainsKey(customerType))
        {
            iReturn = DailyCount[customerType];
        }
        return iReturn;
    }
    //�մ� Ÿ�Ժ� ���ͱ� ��ȯ �Լ�
    public int getDailyRevenue(string customerType)
    {
        int iReturn = 0;
        if(DailyRevenue.ContainsKey(customerType))
        {
            iReturn = DailyRevenue[customerType];
        }
        return iReturn;
    }
    //�մ� Ÿ�Ժ� ������ ��ȯ �Լ�
    public int getDailyCs(string customerType)
    {
        int iReturn = 0;
        if(DailyCS.ContainsKey(customerType))
        {
            iReturn = DailyCS[customerType];
        }
        return iReturn;
    }
    // ������ �Ѿ �� ����
    public void NextDay()
    {
        Init();
    }
    public void AddValues(string customerType, int payment, int cs)
    {
        Debug.Log("AddValues �����.");
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
