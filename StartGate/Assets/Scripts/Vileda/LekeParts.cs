using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LekeParts : MonoBehaviour
{
    public static LekeParts Instance; // Singleton tasarımı

    private int totalLekes; // Toplam leke sayısı
    private int cleanedLekes = 0; // Temizlenen leke sayısı

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
        Debug.Log($"Toplam leke sayısı: {totalLekes}");
    }

    public void LekeTemizlendi()
    {
        cleanedLekes++; // Temizlenen leke sayısını artır
        Debug.Log($"Temizlenen lekeler: {cleanedLekes}/{totalLekes}");

        // Tüm lekeler temizlendiyse sahneyi değiştir
        if (cleanedLekes >= totalLekes)
        {
            StartCoroutine(SahneDegistir());
        }
    }

    public void CreateBook()
    {
        PlayerImpact playerImpact = GameManager.Instance.player.GetComponent<PlayerImpact>();
        playerImpact.CreateBook();
    }

    private IEnumerator SahneDegistir()
    {
        CreateBook();
        Debug.Log("Tüm lekeler temizlendi, sahne değiştiriliyor...");
        yield return new WaitForSeconds(2f); // 2 saniye bekle
        SceneManager.LoadScene(2); // 1 numaralı sahneyi yükle (numara veya isim verilebilir)
    }
}
