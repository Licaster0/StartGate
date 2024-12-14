using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private PlayerMovement player;
    private bool isReturning;


    [Header("Pierce info")]
    private float pierceAmount;

    private float spinDuration;
    private float spinTimer;
    private float spinDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public void SetupSword(Vector2 _dir, float _gravityScale, PlayerMovement _player)
    {
        player = _player;

        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;

        spinDirection = Mathf.Clamp(rb.velocity.x, -1, 1);

        Invoke("DestroyMe", 7);
    }

    public void SetupPierce(int _pierceAmount)
    {
        pierceAmount = _pierceAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isReturning)
            return;
        StuckInto(collision);
    }
    private void StopWhenSpinning()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        spinTimer = spinDuration;
    }

    private bool spinWasTriggered;

    private void StuckInto(Collider2D collision)
    {
        /*
        if (!spinWasTriggered)
        {
            spinWasTriggered = true;
            StopWhenSpinning();
            return;
        }

        cd.enabled = false;

        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent = collision.transform;
        */
    }
    private void OnBecameVisible()
    {
        Destroy(gameObject, 0.5f);
    }

}
