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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.transform;
        }
    }
    public void Exit() 
    {
        SoundManager.Instance.PlaySFX("door");
        levelManager.playersOut+= 1;
        Destroy(player.gameObject);
    }
}
