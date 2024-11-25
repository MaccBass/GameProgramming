using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newTool", menuName = "Items/Tools")]
public class Tool : ScriptableObject
{
    public string toolName;
    public ToolType toolType;
    public int price;
    public int upgradePrice;
    public int level;
}
