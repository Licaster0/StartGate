using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3;

    private void Update()
    {
        // Inputlar� al�yoruz (Horizontal ve Vertical)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb = gameObject.GetComponent<Rigidbody2D>(); 
        // Hareket vekt�r�n� normalize ediyoruz
        Vector2 normalizedMovement = movement.normalized;

        // Rigidbody ile hareket
        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);
    }

}
