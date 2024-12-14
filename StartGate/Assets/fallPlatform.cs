using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour
{
    public float fadeDuration = 1.5f; // Opakl���n azalaca�� s�re
    public GameObject dustEffect; // Toz efekti Prefab'i
    private SpriteRenderer spriteRenderer;
    private bool isFading = false;
    private Rigidbody2D rb;
    public float fallDelay = 1f; // Platformun d��me s�resi
    public float destroyDelay = 2f; // Platformun yok olma s�resi

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); // Platformun Sprite Renderer'�n� al
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static; // Ba�lang��ta platform hareket etmesin

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFading) // Oyuncu de�di�inde ve opakl�k ba�lamad�ysa
        {
            //StartCoroutine(FadeOut()); // Opakl�k azaltma i�lemini ba�lat
            Invoke("Fall", fallDelay); // Gecikmeli d��me
            isFading = true;
        }

    }

    private void Fall()
    {
        if (dustEffect != null)
        {
            Instantiate(dustEffect, transform.position, Quaternion.identity);
        }
        rb.bodyType = RigidbodyType2D.Dynamic; // Rigidbody'yi serbest b�rak
        Invoke("fallStatic", 4f);
        //Destroy(gameObject, destroyDelay); // Belirli bir s�re sonra platformu yok et
    }
    void fallStatic()
    {
        rb.bodyType = RigidbodyType2D.Static; // Rigidbody'yi serbest b�rak
    }
    private IEnumerator FadeOut()
    {
        isFading = true;
        float elapsed = 0f;
        Color startColor = spriteRenderer.color;

        // Opakl��� azalt�rken d�ng�
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration); // Opakl��� azalt
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Toz efekti olu�tur
        if (dustEffect != null)
        {
            Instantiate(dustEffect, transform.position, Quaternion.identity);
        }

        //Destroy(gameObject); // Platformu yok et
    }
}
