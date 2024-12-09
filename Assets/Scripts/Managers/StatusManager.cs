using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager
{
    public int day;
    public int totalMoney;
    public int playerLevel;
    public int playerExp;

    public void Init()
    {
        day = 1;
        totalMoney = 100000;
        playerLevel = 1;
        playerExp = 0;
    }

    // 현재 playerExp를 보고 Level이 몇이 되어야 하는지 비교
    public void LevelCheck()
    {
        int tempLevel = playerExp / 30 + 1;
        if (tempLevel > playerLevel)
        {
            Debug.Log("레벨 " + tempLevel + "로 상승");
            playerLevel = tempLevel;
            return;
        }
        else if (tempLevel < playerLevel)
        {
            playerExp = (playerLevel - 1) * 30;
            return;
        }
    }
}
