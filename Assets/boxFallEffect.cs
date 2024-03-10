using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxFallEffect : MonoBehaviour
{
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public bool grounded;
    public bool start;

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);


        if(!grounded)
        {
            start = false;
        }

        if(grounded && !start)
        {
            Debug.Log("Fall");
            SoundManager.Instance.PlaySFX("boximpact");
            start = true;
        }


    }



}
