using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Animator animator;
    private bool isJumping = false;
    private bool wasGrounded = false; // Yere deðip deðmediðini kontrol et

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Animator'ý almak
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

        // Yere deðiyor mu?
        bool isGrounded = IsGrounded();

        // Yere deðmiyorsa ve daha önce yere deðmiþse Jump animasyonunu baþlat
        if (!isGrounded && wasGrounded)
        {
            SetJumpingAnimation(true);  // Jump animasyonunu baþlat
        }

        // Eðer zýplama yapýlýyorsa, Jump animasyonunu baþlat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            SetJumpingAnimation(true);  // Jump animasyonunu baþlat
        }

        // Zýplama sona erdiðinde yere deðiyorsa, Jump animasyonunu bitir
        if (isGrounded && !wasGrounded && rb.velocity.y <= 0)
        {
            SetJumpingAnimation(false);  // Jump animasyonunu bitir
        }

        // Yere deðdiði her frame'de, bu bilgiyi kaydet
        wasGrounded = isGrounded;

        animator.SetFloat("speed", Mathf.Abs(horizontal)); // Hareket animasyonu
        Flip(); // Yön deðiþtirme
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
        // Yer kontrolü için OverlapCircle kullanýyoruz, yerle temas edip etmediðini tespit ediyoruz
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
        // 1. Fade Out (Küçülme ve görünmez olma)
        yield return StartCoroutine(FadeOut());

        // Pozisyonu baþlangýç pozisyonuna sýfýrla
        transform.position = startPosition;

        // 2. Fade In (Yavaþça büyüyerek görünür olma)
        yield return StartCoroutine(FadeIn());
    }

    // Fade Out (Görünmez Olma) Methodu
    private IEnumerator FadeOut()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Fade In (Görünür Olma) Methodu
    private IEnumerator FadeIn()
    {
        float growDuration = 0.5f; // Büyüme süresi
        float elapsed = 0f;

        Vector3 originalScale = transform.localScale;

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
        else
        {
            Debug.Log("Gate deðil");
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
        else
        {
            Debug.Log("Gate deðil");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Gate"))
        {
            promptText.text = ""; // UI öðesindeki metni temizle
        }
        else
        {
            Debug.Log("Gate deðil");
        }
    }

    // Yer kontrolü için çizim
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
