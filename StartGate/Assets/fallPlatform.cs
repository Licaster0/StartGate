using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour
{
    public float fadeDuration = 1.5f; // Opaklýðýn azalacaðý süre
    public GameObject dustEffect; // Toz efekti Prefab'i
    private SpriteRenderer spriteRenderer;
    private bool isFading = false;
    private Rigidbody2D rb;
    public float fallDelay = 1f; // Platformun düþme süresi
    public float destroyDelay = 2f; // Platformun yok olma süresi

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); // Platformun Sprite Renderer'ýný al
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static; // Baþlangýçta platform hareket etmesin

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFading) // Oyuncu deðdiðinde ve opaklýk baþlamadýysa
        {
            //StartCoroutine(FadeOut()); // Opaklýk azaltma iþlemini baþlat
            Invoke("Fall", fallDelay); // Gecikmeli düþme
            isFading = true;
        }

    }

    private void Fall()
    {
        if (dustEffect != null)
        {
            Instantiate(dustEffect, transform.position, Quaternion.identity);
        }
        rb.bodyType = RigidbodyType2D.Dynamic; // Rigidbody'yi serbest býrak
        Invoke("fallStatic", 4f);
        //Destroy(gameObject, destroyDelay); // Belirli bir süre sonra platformu yok et
    }
    void fallStatic()
    {
        rb.bodyType = RigidbodyType2D.Static; // Rigidbody'yi serbest býrak
    }
    private IEnumerator FadeOut()
    {
        isFading = true;
        float elapsed = 0f;
        Color startColor = spriteRenderer.color;

        // Opaklýðý azaltýrken döngü
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration); // Opaklýðý azalt
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Toz efekti oluþtur
        if (dustEffect != null)
        {
            Instantiate(dustEffect, transform.position, Quaternion.identity);
        }

        //Destroy(gameObject); // Platformu yok et
    }
}
