using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    LevelManager levelManager;
    int player;
    bool godMode = true;
    bool candeath = true;
    public List<Transform> lightsPlayerIsIn;
    public List<Transform> potentialLights;
    List<Transform> toChange;
    public GameObject deathEffect;
    Animator animator;

    void Start()
    {
        toChange = new List<Transform>();
        lightsPlayerIsIn= new List<Transform>();
        potentialLights = new List<Transform>();
        player = GetComponent<Movement>().Player;
        levelManager= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelManager>();
        Invoke("SpawnProtectionOff", 0.1f);
        animator = GetComponent<Animator>();
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
            if(player==1&& lightsPlayerIsIn.Count == 0 && candeath)
            {
                animator.SetTrigger("flydeath");
                Invoke("EffectDie", 0f);
                Invoke("EffectParticleDie", 0.8f);
                Invoke("Die", 1.45f);              
            }
            else if(player ==2 && lightsPlayerIsIn.Count>0 && candeath)
            {
                animator.SetTrigger("flydeath");
                Invoke("EffectDie", 0f);
                Invoke("EffectParticleDie", 0.8f);
                Invoke("Die", 1.45f);
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
        candeath = true;
    }

    void EffectDie()
    {
            foreach(GameObject players in GameObject.FindGameObjectsWithTag("Player"))
            {
                players.GetComponent<Movement>().enabled = false;
                players.GetComponent<Rigidbody2D>().isKinematic = true;
                players.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                players.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            SoundManager.Instance.PlaySFX("death");
            candeath = false;

    }
    void EffectParticleDie()
    {
        GameObject effectInstance1 = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effectInstance1, 3f);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
