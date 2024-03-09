using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallButton : MonoBehaviour
{
    bool playerIn;
    bool player1In;
    bool player2In;
    public bool isInRange;
    public bool wallOFF;
    public GameObject button;
    public GameObject button2;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


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
        if(collision.tag == "Player")
        {
            playerIn = true;

            if(player.GetComponent<Movement>().Player == 1)
            {
                player1In = true;
            }

            if (player.GetComponent<Movement>().Player == 2)
            {
                player2In = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIn = false;
        }

        if (player.GetComponent<Movement>().Player == 1)
        {
            player1In = false;
        }

        if (player.GetComponent<Movement>().Player == 2)
        {
            player2In = false;
        }
    }
}
