using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour
{
    public Button nextButton;           //�������� �Ѿ�� ��ư
    public string sNextScene = "Open_Customer";            //�ӽ�: ���� �� �̸� �����ϱ�
    private string sHappyEnding = "2. HappyEnding CutScene";    //���� ���� �ƾ�
    private string sBadEnding = "3. BadEnding CutScene";        //��� ���� �ƾ�

    private int iDay;                   //���� ����
    private int iMoneyToPayLoan;
    private DailyResults dailyResults;                  //������ �Ŵ��� ��ũ��Ʈ ���� ����
    // Start is called before the first frame update
    void Start()
    {
        if (nextButton == null)
        { }
        else
        {
            iDay = dailyResults.getiDay();
            nextButton.onClick.AddListener(OnNextButtonClick);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //��ư Ŭ���� ȣ��Ǵ� �Լ�
    private void OnNextButtonClick()
    {
        if ((iDay < 7) && (iDay > 0))
        {
            //���� ������ �̵�
            SceneManager.LoadScene(sNextScene);
        }
        //�ӽ�. day count�� 1���� �����Ұ��� 0���� �����Ұ��� Ȯ�� �ʿ�. �ϴ� 1���� �����Ѵٰ� �����ϰ� �ۼ���
        else if (iDay > 7)
        {
            //���� ����
            if(setEnding() == true)
            {
                SceneManager.LoadScene(sHappyEnding);
            }
            //��� ����
            else
            {
                SceneManager.LoadScene(sBadEnding);
            }
        }
        else
        {
            Debug.Log("�ùٸ��� ���� day");
            //���� �߻��� �� ���� ����
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
    private bool setEnding()
    {
        bool bIsHappyEnding = false;
        iMoneyToPayLoan = dailyResults.getiMoneyToPayLoan();
        if (iMoneyToPayLoan > 0)
        {
            bIsHappyEnding = false;
        }
        else
        {
            bIsHappyEnding = true;
        }
        return bIsHappyEnding;
    }
}
