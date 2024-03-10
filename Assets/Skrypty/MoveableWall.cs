using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveableWall : MonoBehaviour
{
    [SerializeField] string soundName;
    [SerializeField] List<Transform> towards;
    [SerializeField] float moveSpeed;
    [SerializeField] bool loop;
    public void Move()
    {
        MoveToOne(0);
    }

    void MoveToOne(int ind)
    {
        SoundManager.Instance.PlaySFX(soundName);
        transform.DOMove(towards[ind].position, moveSpeed).OnComplete(() =>
        {
            if (ind < towards.Count-1)
            {
                MoveToOne(ind + 1);
            }else if(loop)
            {
                MoveToOne(0);
            }
        });
    }
}
