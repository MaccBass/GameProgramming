using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class ToolUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject toolObj;

    void OnEnable()
    {
        // ���� UI ����
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // ��ư ����
        foreach (var tool in Managers.Inventory.Tools.ToList())
        {

            GameObject obj = Instantiate(toolObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // ��ư �̹���
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = tool.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(tool));
            button.onClick.AddListener(() => OnRightClick(tool));

            // ���� ǥ��
            Text toolLevel = obj.GetComponentInChildren<Text>();
            toolLevel.text = "Lv" + tool.level.ToString();
        }
    }

    void OnLeftClick(Tool tool)
    {
        // ��Ŭ����
    }

    void OnRightClick(Tool tool)
    {
        // ��Ŭ����
        Debug.Log("���� " + tool.itemName + " Ŭ����.");
    }
}