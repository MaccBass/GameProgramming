using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderStatus {
    ORDERED,
    DELAYED,
    SERVED,
    CANCELED
}

[System.Serializable]
public class Order
{
    public int orderId;
    public Table table;
    public Customer customer;
    public Item orderItem;
    public float orderTime;
    public OrderStatus status;
    public GameObject orderUI;

    public Order(int orderId, Table table, Customer customer, Item orderItem, float orderTime, GameObject orderUI) {
        this.orderId = orderId;
        this.table = table;
        this.customer = customer;
        this.orderItem = orderItem;
        this.orderTime = orderTime;
        this.status = OrderStatus.ORDERED;
        this.orderUI = orderUI;
    }
}
