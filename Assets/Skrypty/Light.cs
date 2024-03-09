using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    Transform player;
    bool playerInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerLight>().potentialLights.Add(transform);
            //collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Add(transform);
            /*
            player = collision.transform;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, 100.0f) ;
            if(hit && hit.collider.tag =="Player")
            {
                playerInside = true;
                collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Add(transform);
            }
            */
        }
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
                collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Add(transform);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, 100.0f) ;
            Debug.DrawRay(transform.position, player.position - transform.position);
            //if(hit.collider.tag !="Player" && playerInside)
            if (hit.collider.tag != "Player")
            {
                //playerInside = false;
                collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Remove(transform);
                //}else if(hit.collider.tag == "Player" && !playerInside)
            }
            else if (hit.collider.tag == "Player")
            {
                collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Add(transform);
            }
        }
        
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Contains(transform))
            {
                collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Remove(transform);
            }else
            {
                collision.GetComponent<PlayerLight>().potentialLights.Remove(transform);
            }
            //playerInside = false;
        }
    }
}
