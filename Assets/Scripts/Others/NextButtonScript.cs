using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour
{
    public Button nextButton;           //�������� �Ѿ�� ��ư
    public string sNextScene;            //�ӽ�: ���� �� �̸� �����ϱ�
    // Start is called before the first frame update
    void Start()
    {
        if (nextButton == null)
        { }
        else
        {
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
        //���� ������ �̵�
        SceneManager.LoadScene(sNextScene);
    }
}
