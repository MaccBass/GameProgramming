using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_PlayerController : MonoBehaviour
{
    public static Temp_PlayerController Instance { get; private set; }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public float speed = 5.0f;

    private Vector2 lookDirection = Vector2.zero;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private int mask;

    void Start() {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mask = LayerMask.GetMask("Cooker", "Table", "Fridge", "TrashCan");
    }

    void Update() {
        if (Temp_UIManager.Instance.isPopupActive()) return;
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
            Collider2D collider = getRay();
            if (collider == null) return;
            
            if (collider.gameObject.layer == 8) {  // cooker
                collider.GetComponent<Cooker>().prepareCooking();
            }
            if (collider.gameObject.layer == 9) { // table
                collider.GetComponent<Table>().cleanTable();
            }
            if (collider.name == "Fridge") {
                Debug.Log(collider.name);
                collider.GetComponent<Fridge>().showPopup();
            }
            if (collider.name == "DrinkFridge") {
                Debug.Log(collider.name);
                collider.GetComponent<DrinkFridge>().showPopup();
            }
        }
    }

    public Collider2D getRay() { // 냉장고, 쿠커, 테이블, 쓰레기통 (냉장고,쿠너 -> popManager)
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, mask);
        return (hit.collider);
    }
}
