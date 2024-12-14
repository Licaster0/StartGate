using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titreme : MonoBehaviour
{
    // Titreme için
    public float trembleAmount = 0.1f; // Titreme miktarı
    public float trembleSpeed = 10f;   // Titreme hızı

    // Sürükleme için
    private bool isDragging = false;  // Sürükleme durumu
    private Vector3 offset;           // Fare ile nesne arasındaki mesafe
    private Camera mainCamera;        // Ana kamera referansı

    void Start()
    {
        mainCamera = Camera.main; // Ana kamerayı al
    }

    void Update()
    {
        // Titreme efekti sadece sürüklenmiyorsa çalışır
        if (!isDragging)
        {
            TrembleEffect();
        }

        // Sürükleme işlemi
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseDown()
    {
        // Sürüklemeyi başlat
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        // Sürüklemeyi bitir
        isDragging = false;
    }

    private void TrembleEffect()
    {
        // Titreme efekti, sadece nesne normal hareket ediyorken çalışır
        float x = Mathf.Sin(Time.time * trembleSpeed) * trembleAmount;
        float y = Mathf.Cos(Time.time * trembleSpeed) * trembleAmount;
        // Titreme sadece orijinal pozisyonda etki eder
        transform.position = transform.position + new Vector3(x, y, 0);
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Fare pozisyonunu dünya pozisyonuna çevir
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // Kameraya olan mesafe
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
