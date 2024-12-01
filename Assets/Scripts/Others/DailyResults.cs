using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyResults : MonoBehaviour
{
    public Text ResultText;             //Result �ؽ�Ʈ
    public Text TotalGainText;          //���� ���� ��&����ġ �ؽ�Ʈ
    public Text CustomerSatisfiedResultText; //����&�Ҹ��� �մ� �� �ؽ�Ʈ
    public Text RateText;               //���� �ؽ�Ʈ



    public Text loanText;               //���� ��ȯ���� ���� �� �ؽ�Ʈ
    public Text TotalMoneyText;         //�� ������ �ؽ�Ʈ

    public Button nextButton;           //�������� �Ѿ�� ��ư
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Rate(����) �ؽ�Ʈ �� ���� �Լ�
    public void SetRateText()
    {
        if (RateText == null)
        {
            return;
        }
        //Rate �ؽ�Ʈ ���� �� �� ����
        else
        {
            string sRate = RateText.text;
            switch(sRate)
            {
                case "S":
                    RateText.color = Color.red;         //�۾� ������
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
    //Rate(����) �ؽ�Ʈ �ܰ��� �� ���� �Լ�
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
