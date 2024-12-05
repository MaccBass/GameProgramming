using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int orderId;
    public Table table;
    public Customer customer;
    public Food menu;
    public float orderTime;
    public string status;
    public GameObject orderUI;

    public Order(int orderId, Table table, Customer customer, Food menu, float orderTime, GameObject orderUI) {
        this.orderId = orderId;
        this.table = table;
        this.customer = customer;
        this.menu = menu;
        this.orderTime = orderTime;
        this.status = "ORDERED";
        this.orderUI = orderUI;
    }
}
