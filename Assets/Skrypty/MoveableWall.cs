using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveableWall : MonoBehaviour
{
    [SerializeField] Transform towards;
    [SerializeField] float moveSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Move()
    {
        //transform.position = Vector2.MoveTowards(transform.position, towards.position, 1.0f);
        Debug.Log(towards.position - transform.position);
        transform.DOMove(towards.position, moveSpeed);
    }
}
