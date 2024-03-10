using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    LevelManager levelManager;
    int player;
    bool godMode = true;
    public List<Transform> lightsPlayerIsIn;
    public List<Transform> potentialLights;
    List<Transform> toChange;
    void Start()
    {
        toChange = new List<Transform>();
        lightsPlayerIsIn= new List<Transform>();
        potentialLights = new List<Transform>();
        player = GetComponent<Movement>().Player;
        levelManager= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelManager>();
        Invoke("SpawnProtectionOff", 0.1f);
    }

    private void Update()
    {
        foreach(Transform light in potentialLights)
        {
            RaycastHit2D hit = Physics2D.Raycast(light.position, transform.position - light.position, 100.0f) ;
            Debug.DrawRay(light.position, transform.position - light.position);
            if (hit.collider.name == gameObject.name)
            {
                toChange.Add(light);
            }
        }
        foreach(Transform light in lightsPlayerIsIn)
        {
            RaycastHit2D hit = Physics2D.Raycast(light.position, transform.position - light.position, 100.0f) ;
            Debug.DrawRay(light.position, transform.position - light.position);
            if (hit.collider.name != gameObject.name)
            {
                toChange.Add(light);
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
        if(!godMode)
        {
            if(player==1&& lightsPlayerIsIn.Count == 0)
            {
                Die();
            }else if(player ==2 && lightsPlayerIsIn.Count>0)
            {
                Die();
            }
        }
    }

    void SpawnProtectionOff()
    {
        godMode = false;
    }

    void Die()
    {
        levelManager.Restart();
    }
}
