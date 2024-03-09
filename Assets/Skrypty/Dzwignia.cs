using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dzwignia : MonoBehaviour
{
    bool playerIn;
    [SerializeField] bool isOn;
    public UnityEvent on;
    public UnityEvent off;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIn)
        {
            if(isOn)
            {
                off.Invoke();
                isOn = false;
            }else
            {
                on.Invoke();
                isOn = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIn = false;
        }   
    }
}
