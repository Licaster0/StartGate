using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementPlatformer : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    private bool isFacingRight = true;
    private Vector3 startPosition; // Oyuncunun ba�lang�� pozisyonu
    private float groundCheckRadius;
    private SpriteRenderer spriteRenderer; // G�r�nmezlik i�in SpriteRenderer
    public TextMeshProUGUI promptText; // UI eleman�n� burada referansla al
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator animator;
    private bool isJumping = false;
    private bool wasGrounded = false; // Yere de�ip de�medi�ini kontrol et

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Animator'� almak
        animator = GetComponent<Animator>();
        StartCoroutine(FadeInStart());
    }
    private IEnumerator FadeInStart()
    {
        yield return StartCoroutine(FadeIn());
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Yere de�iyor mu?
        bool isGrounded = IsGrounded();

        // Yere de�miyorsa ve daha �nce yere de�mi�se Jump animasyonunu ba�lat
        if (!isGrounded && wasGrounded)
        {
            SetJumpingAnimation(true);  // Jump animasyonunu ba�lat
        }

        // E�er z�plama yap�l�yorsa, Jump animasyonunu ba�lat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            SetJumpingAnimation(true);  // Jump animasyonunu ba�lat
        }

        // Z�plama sona erdi�inde yere de�iyorsa, Jump animasyonunu bitir
        if (isGrounded && !wasGrounded && rb.velocity.y <= 0)
        {
            SetJumpingAnimation(false);  // Jump animasyonunu bitir
        }

        // Yere de�di�i her frame'de, bu bilgiyi kaydet
        wasGrounded = isGrounded;

        animator.SetFloat("speed", Mathf.Abs(horizontal)); // Hareket animasyonu
        Flip(); // Y�n de�i�tirme
    }

    // Jump animasyonunu kontrol et
    private void SetJumpingAnimation(bool isJumping)
    {
        if (isJumping)
        {
            this.isJumping = isJumping;
            //animator.SetBool("isJumping", isJumping);
            animator.CrossFade("jump", 1);
        }
    }

    private bool IsGrounded()
    {
        // Yer kontrol� i�in OverlapCircle kullan�yoruz, yerle temas edip etmedi�ini tespit ediyoruz
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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

    void ResetPosition()
    {
        StartCoroutine(SmoothResetPosition());
    }

    private IEnumerator SmoothResetPosition()
    {
        // 1. Fade Out (K���lme ve g�r�nmez olma)
        yield return StartCoroutine(FadeOut());

        // Pozisyonu ba�lang�� pozisyonuna s�f�rla
        transform.position = startPosition;

        // 2. Fade In (Yava��a b�y�yerek g�r�n�r olma)
        yield return StartCoroutine(FadeIn());
    }

    // Fade Out (G�r�nmez Olma) Methodu
    private IEnumerator FadeOut()
    {
        float shrinkDuration = 0.5f; // K���lme s�resi
        float elapsed = 0f;

        Vector3 originalScale = transform.localScale;

        // Rigidbody h�z�n� s�f�rla
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        while (elapsed < shrinkDuration)
        {
            float t = elapsed / shrinkDuration;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t); // K���lme
            spriteRenderer.color = new Color(1, 1, 1, 1 - t); // G�r�nmez olma
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero; // Tamamen k���l
        spriteRenderer.color = new Color(1, 1, 1, 0); // Tamamen g�r�nmez
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Fade In (G�r�n�r Olma) Methodu
    private IEnumerator FadeIn()
    {
        float growDuration = 0.5f; // B�y�me s�resi
        float elapsed = 0f;

        Vector3 originalScale = transform.localScale;

        while (elapsed < growDuration)
        {
            float t = elapsed / growDuration;
            transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t); // B�y�me
            spriteRenderer.color = new Color(1, 1, 1, t); // G�r�n�r olma
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale; // Orijinal boyut
        spriteRenderer.color = new Color(1, 1, 1, 1); // Tamamen g�r�n�r
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Gate"))
    //    {
    //        promptText.text = "Press E Key"; // UI ��esine metin atamas�
    //    }
    //    else
    //    {
    //        Debug.Log("Gate de�il");
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Gate"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Debug.Log("deneme");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Gate de�il");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Gate"))
    //    {
    //        promptText.text = ""; // UI ��esindeki metni temizle
    //    }
    //    else
    //    {
    //        Debug.Log("Gate de�il");
    //    }
    //}

    //// Yer kontrol� i�in �izim
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    //}
}
