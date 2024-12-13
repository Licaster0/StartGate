using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3;
    private Vector3 originalScale;
    private void Start()
    {
        originalScale = transform.localScale;
        rb =this.gameObject.GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        Vector2 normalizedMovement = movement.normalized;

        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x > 0)
        {
            // Saða gidiyorsa
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (movement.x < 0)
        {
            // Sola gidiyorsa
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }

}
