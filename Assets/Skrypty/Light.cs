using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light : MonoBehaviour
{
    Collider2D trigger;
    Light2D light;
    public bool turnedOff= false;
    private void Start()
    {
        trigger = GetComponent<Collider2D>();
        light = GetComponent<Light2D>();
        if (turnedOff) TurnOff();
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
    public void Turn()
    {
        if(turnedOff)
        {
            TurnOn();
        }else
        {
            TurnOff();
        }
    }

    void TurnOff()
    {
        turnedOff = true;
        trigger.enabled = false;
        light.enabled = false;
    }
    void TurnOn()
    {
        turnedOff = false;
        trigger.enabled = true;
        light.enabled = true;
    }
}
