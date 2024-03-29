using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    public bool multiUsable;
    public UnityEvent onclick;
    Collider2D trigger;
    // 0 - none
    int playerNum;
    [SerializeField] GameObject player1Anim;
    [SerializeField] GameObject player2Anim;


    private void Start()
    {
        player1Anim.GetComponent<SpriteRenderer>().enabled = false;
        player2Anim.GetComponent<SpriteRenderer>().enabled = false;
        trigger = GetComponent<Collider2D>();
    }


    private void Update()
    {
        if (playerNum == 1 && Input.GetKeyDown(KeyCode.E) || playerNum == 2 && Input.GetKeyDown(KeyCode.I))
        {
            if (!multiUsable) trigger.enabled = false;
            onclick.Invoke();
            SoundManager.Instance.PlaySFX("click");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerNum = collision.GetComponent<Movement>().Player;
            if(playerNum==1)
            {
                player1Anim.GetComponent<SpriteRenderer>().enabled = true;
            }else if(playerNum==2)
            {
                player2Anim.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerNum = 0;
        player1Anim.GetComponent<SpriteRenderer>().enabled = false;
        player2Anim.GetComponent<SpriteRenderer>().enabled = false;
    }
    
}
