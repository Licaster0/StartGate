using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViledaParts : MonoBehaviour
{
    private bool isCollected = false; // Bu parçanın toplanıp toplanmadığını kontrol eder
    public Vileda vileda; // Bağlı olduğu Vileda scriptine referans

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            GameManager.Instance.text.text = "Press E to pick up this part.";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            GameManager.Instance.text.text = "";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isCollected && PlayerInRange())
        {
            Collect();
        }
    }

    private bool PlayerInRange()
    {
        // Oyuncunun parça ile temas halinde olup olmadığını kontrol et
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Collect()
    {
        if (isCollected) return; // Eğer zaten toplandıysa işlemi durdur

        isCollected = true; // Sadece bu parçanın toplandığını işaretle
        gameObject.SetActive(false); // Parçayı sahneden kaldır

        // Vileda scriptine bu parçanın toplandığını bildir
        if (vileda != null)
        {
            vileda.OnPartCollected(); // Vileda'nın toplamayı kontrol etmesini sağla
        }

    }
}
