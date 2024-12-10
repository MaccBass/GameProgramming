using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
    public GameObject dirty;

    void Awake() {
        chairs = new Transform[chairNum];
        for (int i = 0; i < chairNum; i++) {
            chairs[i] = transform.Find($"Chair_{i+1}");
        }
        dirty = transform.Find("Table/dirty").gameObject;
    }

    public void occupy() {
        if (status == TableStatus.EMPTY) {
            status = TableStatus.OCCUPIED;
        }
    }

    public void makeDirty() {
        if (status == TableStatus.OCCUPIED) {
            status = TableStatus.NEEDTOCLEAN;
            dirty.SetActive(true);
        }
    }

    public void cleanTable() {
        if (status == TableStatus.NEEDTOCLEAN) {
            status = TableStatus.EMPTY;
            dirty.SetActive(false);
        }
    }
}
