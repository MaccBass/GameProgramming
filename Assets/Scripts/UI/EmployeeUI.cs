using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class EmployeeUI : MonoBehaviour
{
    public void OnWaiterLeftClick()
    {
        Managers.Prepare.AddWaiter();
    }
    public void OnCookLeftClick()
    {
        Managers.Prepare.AddCook();
    }
}
