using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private ParticleSystem dustFx;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float Ses = 1;
    [SerializeField] private AnimatonController animator;
    private Vector3 originalScale;

    [SerializeField] public AudioSource FootSteepss;
    [SerializeField] public AudioClip footstep;
    private void Start()
    {
        originalScale = transform.localScale;
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    public void FootSteeps()
    {
        FootSteepss.PlayOneShot(footstep); // Footstep sesini bir kez çal
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        Vector2 normalizedMovement = movement.normalized;

        if (movement.x != 0)
        {
            animator.MoveOnAnimator();
        }
        else
        {
            animator.StopOnAnimator();
        }

        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);
        if (movement.x > 0)
        {
            // Sa�a gidiyorsa
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (movement.x < 0)
        {
            // Sola gidiyorsa
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }

}
