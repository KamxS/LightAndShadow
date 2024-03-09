using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    Transform player;
    LevelManager levelManager;
    void Start()
    {
        levelManager= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelManager>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && player)
        {
            levelManager.playersIn += 1;
            Destroy(player.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = null;
        }   
    }

}
