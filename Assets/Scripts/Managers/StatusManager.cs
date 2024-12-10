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

    public AudioClip LevelUpClip;

    public void Init()
    {
        day = 1;
        totalMoney = 100000;
        playerLevel = 1;
        playerExp = 0;
    }

    // ���� playerExp�� ���� Level�� ���� �Ǿ�� �ϴ��� ��
    public void LevelCheck()
    {
        int tempLevel = playerExp / 30 + 1;
        if (tempLevel > playerLevel)
        {

            Debug.Log("���� " + tempLevel + "�� ���");
            PlaySound();
            playerLevel = tempLevel;
            return;
        }
        else if (tempLevel < playerLevel)
        {
            playerExp = (playerLevel - 1) * 30;
            return;
        }
    }
    private void PlaySound()
    {
        LevelUpClip = Resources.Load<AudioClip>("BGM/05-6. levelUp");
        if (LevelUpClip != null)
        {
            AudioSource.PlayClipAtPoint(LevelUpClip, Vector3.zero);
        }
    }
}
