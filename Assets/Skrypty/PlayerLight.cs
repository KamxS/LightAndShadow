using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    int player;
    public List<Transform> lightsPlayerIsIn;
    void Start()
    {
        player = GetComponent<Movement>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        if(player==1&& lightsPlayerIsIn.Count == 0)
        {
            Die();
        }else if(player ==2 && lightsPlayerIsIn.Count>0)
        {
            Die();
        } 
    }

    private void FixedUpdate()
    {
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
