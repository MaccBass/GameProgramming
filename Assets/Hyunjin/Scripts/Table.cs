using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TableStatus {
    EMPTY,
    OCCUPIED,
    NEEDTOCLEAN
}

public class Table : MonoBehaviour
{
    public int id;
    public int chairNum;
    public Transform[] chairs;
    public TableStatus status;

    void Awake() {
        chairs = new Transform[chairNum];
        for (int i = 0; i < chairNum; i++) {
            chairs[i] = transform.Find($"Chair_{i+1}");
        }
    }
}
