using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    [Header("Text Ayarlar�")]
    public TextMeshProUGUI textComponent; // UI TextMeshPro objesi
    [TextArea]
    public string fullText; // Yazd�r�lacak tam metin
    public float typingSpeed = 0.05f; // Harfler aras� gecikme s�resi

    [Header("Ses Ayarlar�")]
    public AudioSource audioSource; // Ses kayna��
    public AudioClip typingSound; // Daktilo sesi
    [Range(0f, 1f)] public float soundVolume = 0.3f; // Ses seviyesi (0.0 - 1.0)

    private Coroutine typingCoroutine;

    void Start()
    {
        StartTypingEffect();
    }
    public void StartTypingEffect()
    {
        // �nceki yazd�rma i�lemini iptal et (e�er varsa)
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        // Text'i s�f�rla
        textComponent.text = "";

        // Yazd�rma Coroutine'ini ba�lat
        typingCoroutine = StartCoroutine(TypeText());
    }
    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter; // Harfi ekle

            // Daktilo sesi �al
            if (typingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typingSound, soundVolume); // Ses seviyesini uygula
            }

            yield return new WaitForSeconds(typingSpeed); // Harf aras� gecikme
        }
    }
}
