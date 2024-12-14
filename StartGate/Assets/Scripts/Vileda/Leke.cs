using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leke : MonoBehaviour
{
    [SerializeField] private Vileda vileda; // Vileda referansı
    [SerializeField] private ParticleSystem freshFx; // Temizlik efekti

    private bool isCollected = false; // Lekeyi temizleme izni

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Eğer Vileda birleştirildiyse temizlemeye izin ver
            if (vileda != null && vileda.isAssembled)
            {
                isCollected = true;
                GameManager.Instance.text.text = "Lekeyi temizlemek için 'E' tuşuna basin.";
            }
            else
            {
                isCollected = false;
                GameManager.Instance.text.text = "Vileda'yi birleştirmeden lekeyi temizleyemezsiniz.";
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollected)
        {
            // Temizlik işlemi
            freshFx.transform.position = transform.position;
            freshFx.Play();
            Destroy(gameObject); // Lekeyi yok et

            // LekeManager'a bildir
            LekeParts.Instance.LekeTemizlendi();
        }
    }
}
