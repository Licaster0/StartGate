using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    [Header("Text Ayarlarý")]
    public TextMeshProUGUI textComponent; // UI TextMeshPro objesi
    [TextArea]
    public string fullText; // Yazdýrýlacak tam metin
    public float typingSpeed = 0.05f; // Harfler arasý gecikme süresi

    [Header("Ses Ayarlarý")]
    public AudioSource audioSource; // Ses kaynaðý
    public AudioClip typingSound; // Daktilo sesi
    [Range(0f, 1f)] public float soundVolume = 0.3f; // Ses seviyesi (0.0 - 1.0)

    private Coroutine typingCoroutine;

    void Start()
    {
        StartTypingEffect();
    }
    public void StartTypingEffect()
    {
        // Önceki yazdýrma iþlemini iptal et (eðer varsa)
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        // Text'i sýfýrla
        textComponent.text = "";

        // Yazdýrma Coroutine'ini baþlat
        typingCoroutine = StartCoroutine(TypeText());
    }
    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter; // Harfi ekle

            // Daktilo sesi çal
            if (typingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typingSound, soundVolume); // Ses seviyesini uygula
            }

            yield return new WaitForSeconds(typingSpeed); // Harf arasý gecikme
        }
    }
}
