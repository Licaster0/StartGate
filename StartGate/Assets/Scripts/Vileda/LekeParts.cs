using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LekeParts : MonoBehaviour
{
    public static LekeParts Instance; // Singleton tasarımı

    public int totalLekes; // Toplam leke sayısı
    public int cleanedLekes = 0; // Temizlenen leke sayısı

    private void Awake()
    {
        // Singleton kontrolü
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Sahnedeki tüm "Leke" objelerini say
        totalLekes = FindObjectsOfType<Leke>().Length;
    }

    public void LekeTemizlendi()
    {
        cleanedLekes++; // Temizlenen leke sayısını artır

        // Tüm lekeler temizlendiyse sahneyi değiştir
        if (cleanedLekes >= totalLekes)
        {
            GameManager.Instance.text.text = "Tum Lekeler Temizlendi Geciti Aktif Et!";
        }
    }
}
