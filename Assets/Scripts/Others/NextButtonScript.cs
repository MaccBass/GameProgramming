using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour
{
    public Button nextButton;           //다음날로 넘어가는 버튼
    public string sNextScene;            //임시: 다음 씬 이름 지정하기
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

    //버튼 클릭시 호출되는 함수
    private void OnNextButtonClick()
    { 
        //다음 씬으로 이동
        SceneManager.LoadScene(sNextScene);
    }
}
