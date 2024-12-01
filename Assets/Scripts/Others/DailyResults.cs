using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyResults : MonoBehaviour
{
    public Text ResultText;             //Result 텍스트
    public Text TotalGainText;          //오늘 얻은 돈&경험치 텍스트
    public Text CustomerSatisfiedResultText; //만족&불만족 손님 수 텍스트
    public Text RateText;               //평점 텍스트



    public Text loanText;               //대출 상환까지 남은 돈 텍스트
    public Text TotalMoneyText;         //총 소지금 텍스트

    public Button nextButton;           //다음날로 넘어가는 버튼
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Rate(평점) 텍스트 색 지정 함수
    public void SetRateText()
    {
        if (RateText == null)
        {
            return;
        }
        //Rate 텍스트 설정 및 색 설정
        else
        {
            string sRate = RateText.text;
            switch(sRate)
            {
                case "S":
                    RateText.color = Color.red;         //글씨 빨간색
                    AddTextOutline(RateText, Color.black);
                    break;
                case "A+": case "A":
                    RateText.color = Color.yellow;
                    AddTextOutline(RateText, Color.black);
                    break;
                case "B+": case "B":
                    RateText.color = Color.green;
                    AddTextOutline(RateText, Color.black);
                    break;
                case "C+": case "C":
                    RateText.color = Color.blue;
                    AddTextOutline(RateText, Color.black);
                    break;
                default:
                    RateText.color = Color.black;
                    AddTextOutline(RateText, Color.black);
                    break;
            }
        }
    }
    //Rate(평점) 텍스트 외곽선 색 지정 함수
    private void AddTextOutline(Text text, Color outlineColor)
    {
        Outline outline = text.GetComponent<Outline>();
        if (outline == null)
        {
            outline = text.gameObject.AddComponent<Outline>();
        }
        outline.effectColor = outlineColor;
        outline.effectDistance = new Vector2(1.5f, -1.5f);
    }
}
