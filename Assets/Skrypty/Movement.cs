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
    public bool OnPlatform;


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
        animator.SetBool("walk", walk);

        if (!grounded)
        {
            walk = false;
        }

        if (Player == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) && grounded)
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                SoundManager.Instance.PlaySFX("jump");
            }
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        }
        else if(Player == 2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                SoundManager.Instance.PlaySFX("jump");
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


    public void RandomFootStep()
    {
        int randomnumber = Random.Range(0, 5);
        {
            if(randomnumber == 0)
            {
                SoundManager.Instance.PlaySFX("step1");
            }
            if (randomnumber == 1)
            {
                SoundManager.Instance.PlaySFX("step2");
            }
            if (randomnumber == 2)
            {
                SoundManager.Instance.PlaySFX("step3");
            }
            if (randomnumber == 3)
            {
                SoundManager.Instance.PlaySFX("step4");
            }
            if (randomnumber == 4)
            {
                SoundManager.Instance.PlaySFX("step5");
            }
        }
    }
}
