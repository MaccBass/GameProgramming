using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// ��� ��� UI ȭ��, Enable �ɶ����� ������.
public class EmployeeUI : MonoBehaviour
{
    void OnWaiterLeftClick()
    {
        Managers.Prepare.AddWaiter();
    }
    void OnCookLeftClick()
    {
        Managers.Prepare.AddCook();
    }
}
