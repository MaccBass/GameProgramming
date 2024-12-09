using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// 재료 목록 UI 화면, Enable 될때마다 갱신함.
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
