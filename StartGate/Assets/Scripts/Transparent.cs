using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    private Transform player; // Oyuncunun pozisyonunu takip etmek için
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni
    public float fadeDistance = 5f; // Transparanlık için maksimum mesafe
    public float minAlpha = 0.2f; // En düşük alfa değeri (yaklaştıkça)
    public float maxAlpha = 1f; // En yüksek alfa değeri (uzaklaştıkça)

    private void Start()
    {
        // Oyuncuyu bulmak için tag ile referans alıyoruz
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
        }

        // SpriteRenderer bileşenini alıyoruz
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
        }
    }

    private void Update()
    {
        if (player == null || spriteRenderer == null) return;

        // Mesafeyi hesapla
        float distance = Vector3.Distance(player.position, transform.position);

        // Mesafeye göre alfa değerini ters şekilde hesapla
        float alpha = Mathf.Clamp((distance / fadeDistance), minAlpha, maxAlpha);

        // Sprite'ın rengini güncelle
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
}
