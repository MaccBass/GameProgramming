using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CustomerType", menuName="InGame/CustomerType")]
public class CustomerType : ScriptableObject
{
    public bool isEvent; // bad, influencer
    public string typeName;
    public List<GameObject> prefabs;
    public float MinStayDuration;
    public float MaxStayDuration;
    public float MinOrderInterval;
    public float MaxOrderInterval;
}
