using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Player;
    Rigidbody2D rb;
    [SerializeField] Transform ground;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    //public bool onGround =true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if(Player == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) )
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        }else if(Player == 2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) )
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal2") * speed, rb.velocity.y);
        }
        //onGround = Physics2D.Raycast(transform.position, new Vector2(0, -1f), 0.01f, 8);
    }
}
