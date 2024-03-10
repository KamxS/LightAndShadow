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
    public bool onGround =true;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public bool grounded;

    public bool GoRight = true;
    public bool walk;


    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("Walk", walk);

        if (!grounded)
        {
            walk = false;
        }

        if(grounded && rb.velocity.x > 0)
        {
            walk = true;
        }
        else
            walk = false;

        if (Player == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) && grounded)
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }
        else if(Player == 2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal2") * speed, rb.velocity.y);
        }
        onGround = Physics2D.Raycast(transform.position, new Vector2(0, -1f), 0.01f, 8);


        if (rb.velocity.x > 0)
            GoRight = true;

        if(rb.velocity.x < 0)
            GoRight = false;


        if (!GoRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
            transform.eulerAngles = new Vector3(0, 0, 0);


    }
}
