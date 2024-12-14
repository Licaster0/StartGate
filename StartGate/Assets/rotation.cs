using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform centerPoint; // Dönüş merkezi
    public float rotationSpeed = 50f; // Dönüş hızı (derece/saniye)
    public float radius = 2f; // Yörüngenin yarıçapı

    private float angle = 0f; // Mevcut açı (radyan cinsinden)
    private bool isDragging = false; // Sürükleme durumu
    private Vector3 offset; // Fare ve nesne arasındaki mesafe
    private Camera mainCamera; // Ana kamera referansı

    void Start()
    {
        mainCamera = Camera.main; // Ana kamerayı al
    }

    void Update()
    {
        if (!isDragging) // Sürükleme yapılmıyorsa dairesel hareket
        {
            // Açıyı güncelle
            angle += rotationSpeed * Time.deltaTime;

            // Radyan cinsine çevir
            float radians = angle * Mathf.Deg2Rad;

            // Yeni pozisyonu hesapla
            float x = centerPoint.position.x + Mathf.Cos(radians) * radius;
            float y = centerPoint.position.y + Mathf.Sin(radians) * radius;

            // Nesneyi yeni pozisyona taşı
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        // Sürükleme başladığında fare ile nesne arasındaki mesafeyi hesapla
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        Debug.Log("Sürükleme çalışıyor");
    }

    void OnMouseDrag()
    {
        // Nesneyi fare pozisyonuna taşı
        transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        // Sürükleme sona erdi
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Fare pozisyonunu dünya pozisyonuna çevir
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // Kameraya olan mesafe
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
