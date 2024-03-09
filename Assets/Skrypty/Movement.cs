using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Player;
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Player == 1)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        }else if(Player == 2)
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            Debug.Log(Input.GetAxis("Horizontal2"));
            rb.velocity = new Vector2(Input.GetAxis("Horizontal2") * speed, rb.velocity.y);

        }
    }
}
