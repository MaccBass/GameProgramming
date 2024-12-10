using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour
{
    public Button nextButton;           //�������� �Ѿ�� ��ư
    public string sNextScene = "InGame_Prepare";            
    private string sHappyEnding = "2. HappyEnding CutScene";    //���� ���� �ƾ�
    private string sBadEnding = "3. BadEnding CutScene";        //��� ���� �ƾ�

    private int iDay;                   //���� ����
    private int iMoneyToPayLoan;
    private DailyResults dailyResults;                  //������ �Ŵ��� ��ũ��Ʈ ���� ����
    // Start is called before the first frame update
    void Start()
    {
        if(Managers.Status == null)
        {
            Debug.Log("Managers.Status�� null�Դϴ�.");
            return;
        }
        if (nextButton == null)
        { }
        else
        {
            iDay = Managers.Status.day;
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
            Managers.Status.day = iDay + 1;
            //���� ������ �̵�
            SceneManager.LoadScene(sNextScene);
        }
        
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
