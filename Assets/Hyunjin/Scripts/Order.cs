using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int orderId;
    public string menuName;
    public int tableNumber;
    // public GameObject customer;
    public float totalTime; // 조리시간

    public Order(int orderId, string menuName, int tableNumber, float totalTime) {
        this.orderId = orderId;
        this.menuName = menuName;
        this.tableNumber = tableNumber;
        // this.customer = customer;
        this.totalTime = totalTime;
    }
}
