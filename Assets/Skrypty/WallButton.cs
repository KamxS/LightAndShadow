using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallButton : MonoBehaviour
{
    bool playerIn;
    public UnityEvent onClick;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIn)
        {
            onClick.Invoke();
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
