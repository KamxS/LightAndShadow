using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONEWAYPLATFORM : MonoBehaviour
{

    public GameObject currentOneWayPlatform;
    public CircleCollider2D capsuleCollider;

    [SerializeField] private CapsuleCollider2D playerColider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentOneWayPlatform != null)
            {
                capsuleCollider.isTrigger = true;
                StartCoroutine(DisableColision());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableColision()
    {

        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerColider, platformCollider);
        yield return new WaitForSeconds(0.6f);
        Physics2D.IgnoreCollision(playerColider, platformCollider, false);
        capsuleCollider.isTrigger = false;
    }

}
