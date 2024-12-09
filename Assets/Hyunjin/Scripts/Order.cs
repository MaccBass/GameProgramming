using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderStatus {
    ORDERED,
    DELAYED,
    SERVED,
    CANCELED
}

public class Order
{
    public int orderId;
    public Table table;
    public Customer customer;
    public Recipe menu;
    public float orderTime;
    public OrderStatus status;
    public GameObject orderUI;

    public Order(int orderId, Table table, Customer customer, Recipe menu, float orderTime, GameObject orderUI) {
        this.orderId = orderId;
        this.table = table;
        this.customer = customer;
        this.menu = menu;
        this.orderTime = orderTime;
        this.status = OrderStatus.ORDERED;
        this.orderUI = orderUI;
    }
}
