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
        transform.DOMove(towards.position, moveSpeed);
        SoundManager.Instance.PlaySFX("stronedrag");
    }
}
