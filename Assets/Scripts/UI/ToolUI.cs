using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
public class ToolUI : MonoBehaviour
{
    public Transform posBase;
    public GameObject toolObj;

    void OnEnable()
    {
        // 기존 UI 제거
        foreach (Transform child in posBase)
        {
            Destroy(child.gameObject);
        }

        // 버튼 생성
        foreach (var tool in Managers.Inventory.Tools.ToList())
        {

            GameObject obj = Instantiate(toolObj, posBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            // 버튼 이미지
            Image iconImage = button.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = tool.icon;
            }

            // OnClick
            button.onClick.AddListener(() => OnLeftClick(tool));
            button.onClick.AddListener(() => OnRightClick(tool));

            // 수량 표시
            Text toolLevel = obj.GetComponentInChildren<Text>();
            toolLevel.text = "Lv" + tool.level.ToString();
        }
    }

    void OnLeftClick(Tool tool)
    {
        // 좌클릭시
    }

    void OnRightClick(Tool tool)
    {
        // 우클릭시
        Debug.Log("도구 " + tool.itemName + " 클릭됨.");
    }
}
