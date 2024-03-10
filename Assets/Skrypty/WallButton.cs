using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallButton : MonoBehaviour
{
    bool playerIn;
    public bool player1In;
    public bool player2In;
    public bool isInRange;
    public bool wallOFF;
    public GameObject button;
    public GameObject button2;



    private void Update()
    {

            if (player1In && !wallOFF)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    wallOFF = true;
                    button.GetComponent<SpriteRenderer>().enabled = false;
                }

                if (player1In && !wallOFF)
                {
                    button.GetComponent<SpriteRenderer>().enabled = true;
                }

            }
            if (!player1In)
                button.GetComponent<SpriteRenderer>().enabled = false;
        


            if (player2In && !wallOFF)
            {

                if (Input.GetKeyDown(KeyCode.I))
                {
                    wallOFF = true;
                    button2.GetComponent<SpriteRenderer>().enabled = false;
                }

                if (player2In && !wallOFF)
                {
                    button2.GetComponent<SpriteRenderer>().enabled = true;
                }

            }
            if (!player2In)
                button2.GetComponent<SpriteRenderer>().enabled = false;
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player1")
        {
            playerIn = true;
                player1In = true;
        }

        if (collision.tag == "Player2")
        {
            playerIn = true;
                player2In = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player1")
        {
            playerIn = false;
            player1In = false;
        }

        if (collision.tag == "Player2")
        {
            playerIn = false;
            player2In = false;
        }
    }
}
