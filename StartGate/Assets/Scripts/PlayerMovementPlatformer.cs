using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovementPlatformer : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    private bool isFacingRight = true;
    private Vector3 startPosition; // Oyuncunun baþlangýç pozisyonu
    private float groundCheckRadius;
    private SpriteRenderer spriteRenderer; // Görünmezlik için SpriteRenderer
    public TextMeshProUGUI promptText; // UI elemanýný burada referansla al
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Animator referansý
    private Animator animator;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();    
        // Animator'ý almak
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("speed", Vector2.ClampMagnitude(rb.velocity, 1).magnitude);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            ResetPosition();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void ResetPosition()
    {
        StartCoroutine(SmoothResetPosition());
    }
    private IEnumerator SmoothResetPosition()
    {
        // 1. Küçülerek görünmez olma
        float shrinkDuration = 0.5f; // Küçülme süresi
        float elapsed = 0f;

        Vector3 originalScale = transform.localScale;

        // Rigidbody hýzýný sýfýrla
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        while (elapsed < shrinkDuration)
        {
            float t = elapsed / shrinkDuration;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t); // Küçülme
            spriteRenderer.color = new Color(1, 1, 1, 1 - t); // Görünmez olma
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero; // Tamamen küçül
        spriteRenderer.color = new Color(1, 1, 1, 0); // Tamamen görünmez

        // Pozisyonu baþlangýç pozisyonuna sýfýrla
        transform.position = startPosition;

        // 2. Yavaþça büyüyerek görünür olma
        float growDuration = 0.5f; // Büyüme süresi
        elapsed = 0f;

        while (elapsed < growDuration)
        {
            float t = elapsed / growDuration;
            transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t); // Büyüme
            spriteRenderer.color = new Color(1, 1, 1, t); // Görünür olma
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale; // Orijinal boyut
        spriteRenderer.color = new Color(1, 1, 1, 1); // Tamamen görünür


    }
    /*
    private IEnumerator SmoothResetPosition()
    {
        float duration = 1f;
        float elapsed = 0f;
        Vector3 currentPosition = transform.position;
        Vector3 originalScale = transform.localScale;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(currentPosition, startPosition, elapsed / duration);
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 0.5f, elapsed / duration); // Küçült
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        transform.localScale = originalScale; // Orijinal boyutuna dön
    }
    */
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
        if (collision.CompareTag("Gate"))
        {
            promptText.text = "Press E Key"; // UI öðesine metin atamasý
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
        if (collision.CompareTag("Gate"))
        {
            promptText.text = ""; // UI öðesindeki metni temizle
        }
    }

    // Yer kontrolü için çizim
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
