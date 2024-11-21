using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 3.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += Vector3.right * horizontal * _speed * Time.deltaTime;
        transform.position += Vector3.up * vertical * _speed * Time.deltaTime;
    }
}
