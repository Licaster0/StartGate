using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementPlatformer : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    private bool isFacingRight = true;
    private float groundCheckRadius;
    public TextMeshProUGUI promptText; // UI eleman�n� burada referansla al
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er triggera giren nesne hedefledi�iniz oyuncu ise
        if (collision.CompareTag("Gate"))
        {
            promptText.text = "Press E Key"; // UI ��esine metin atamas�
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Gate"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("deneme");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Triggerdan ��kan nesne
        if (collision.CompareTag("Gate"))
        {
            promptText.text = ""; // UI ��esindeki metni temizle
        }
    }

    private void OnDrawGizmos()
    {
        // Yer kontrol� i�in �izim
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
