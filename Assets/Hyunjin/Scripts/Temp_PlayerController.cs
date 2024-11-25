using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector2 lookDirection = Vector2.zero;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;
        position += move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        if (Input.GetKeyDown(KeyCode.Z)) {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Cooker"));
            if (hit.collider != null) {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
