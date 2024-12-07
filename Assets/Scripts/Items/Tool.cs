using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newTool", menuName = "Items/Tools")]
public class Tool : Item
{
    public ToolType toolType;
    public int upgradePrice;
    public int level;
    public int amount;
}
