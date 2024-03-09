using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    int player;
    public List<Transform> lightsPlayerIsIn;
    public List<Transform> potentialLights;
    public List<Transform> toChange;
    void Start()
    {
        player = GetComponent<Movement>().Player;
    }

    private void Update()
    {
        foreach(Transform light in potentialLights)
        {
            RaycastHit2D hit = Physics2D.Raycast(light.position, transform.position - light.position, 100.0f) ;
            Debug.DrawRay(light.position, transform.position - light.position);
            //if(hit.collider.tag !="Player" && playerInside)
            if (hit.collider.tag == "Player")
            {
                toChange.Add(light);
                //lightsPlayerIsIn.Add(light);
                //potentialLights.Remove(light);
            }
            /*
            else if (hit.collider.tag == "Player")
            {
                lightsPlayerIsIn.Add(light);
                collision.GetComponent<PlayerLight>().lightsPlayerIsIn.Add(transform);
            }
            */
        }
        foreach(Transform light in lightsPlayerIsIn)
        {
            RaycastHit2D hit = Physics2D.Raycast(light.position, transform.position - light.position, 100.0f) ;
            Debug.DrawRay(light.position, transform.position - light.position);
            if (hit.collider.tag != "Player")
            {
                Debug.Log("Wyjebaæ œwiat³o");
                toChange.Add(light);
                // lightsPlayerIsIn.Remove(light);
                //potentialLights.Add(light);
            }

        }
        foreach(Transform light in toChange)
        {
            if(lightsPlayerIsIn.Contains(light))
            {
                lightsPlayerIsIn.Remove(light);
                potentialLights.Add(light);
            }else
            {
                lightsPlayerIsIn.Add(light);
                potentialLights.Remove(light);
            }
        }
        toChange.Clear();
        if(player==1&& lightsPlayerIsIn.Count == 0)
        {
            Die();
        }else if(player ==2 && lightsPlayerIsIn.Count>0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
