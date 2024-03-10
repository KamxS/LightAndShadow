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
        if(playerNum == 1 && Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.Instance.PlaySFX("click");
            onclick.Invoke();
            if (!multiUsable) trigger.enabled=false;
        }else if(playerNum==2 && Input.GetKeyDown(KeyCode.I))
        {
            SoundManager.Instance.PlaySFX("click");
            onclick.Invoke();
            if (!multiUsable) trigger.enabled=false;
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
