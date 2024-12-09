using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KitchenUI : MonoBehaviour
{
    public Transform toolPosBase;
    public GameObject toolObj;
    public GameObject employeeObj;

    private void OnEnable()
    {
        UpdateToolUI();
        UpdateEmployeeUI();
    }

    private void LateUpdate()
    {
        if (Managers.Prepare.toolUpdated)
        {
            UpdateToolUI();
            Managers.Prepare.toolUpdated = false;
        }
        if (Managers.Prepare.employeeUpdated)
        {
            UpdateEmployeeUI();
            Managers.Prepare.employeeUpdated = false;
        }
    }

    void UpdateToolUI()
    {
        foreach (Transform child in toolPosBase)
        {
            Destroy(child.gameObject);
        }

        foreach (var tool in Managers.Prepare.Tools.ToList())
        {
            GameObject obj = Instantiate(toolObj, toolPosBase);
            Button button = obj.GetComponent<Button>();
            button.transform.localScale = Vector3.one;

            Image iconImage = obj.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = tool.icon;
            }
            button.onClick.AddListener(() => OnToolLeftClick(tool));

            Text level = obj.GetComponentInChildren<Text>();
            level.text = "Lv" + tool.level.ToString();
        }
    }

    void UpdateEmployeeUI()
    {

    }

    void OnToolLeftClick(Tool tool)
    {
            Managers.Prepare.DeleteTool(tool);
    }
}
