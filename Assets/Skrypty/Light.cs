using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light : MonoBehaviour
{
    Collider2D trigger;
    Light2D light;
    private void Start()
    {
        trigger = GetComponent<Collider2D>();
        light = GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerLight>().potentialLights.Add(transform);
        }
    }
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
        }
        
    }

    public void TurnOff()
    {
        trigger.enabled = false;
        light.enabled = false;
    }
    public void TurnOn()
    {

    }
}
