using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string _touch = null;
    public GameObject fryerUI;
    public GameObject burnerUI;
    public GameObject potUI;
    public GameObject storageUI;
    public GameObject drinkUI;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (_touch != null)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (_touch == "Fryer")
                {
                    fryerUI.SetActive(!fryerUI.activeSelf);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _touch = collision.gameObject.tag;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _touch = null;
    }
}
