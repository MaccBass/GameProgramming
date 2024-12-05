using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Food", menuName="InGame/Food")]
public class Food : ScriptableObject
{
    public string name;
    public int price;
    public string cooker;
}
 