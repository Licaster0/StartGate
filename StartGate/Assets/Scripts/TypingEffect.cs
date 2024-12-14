using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    [Header("Text Ayarlar�")]
    public TextMeshProUGUI textComponent; // UI TextMeshPro Text
    public string[] dialogues; // Diyaloglar�n listesi
    public float typingSpeed = 0.05f; // Daktilo yazma h�z�

    [Header("Ses Ayarlar�")]
    public AudioSource audioSource; // Daktilo sesi i�in AudioSource
    public AudioClip typingSound; // Daktilo sesi
    [Range(0f, 1f)] public float soundVolume = 0.3f; // Ses seviyesi

    private int dialogueIndex = 0; // �u anki diyalog indeksi
    private bool isTyping = false; // Yazma i�lemi kontrol�

    void Start()
    {
        textComponent.text = ""; // �lk ba�ta bo� b�rak
    }

    void Update()
    {
        // E tu�una bas�ld���nda bir sonraki diyalogu g�ster
        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            if (dialogueIndex < dialogues.Length)
            {
                StartCoroutine(TypeDialogue(dialogues[dialogueIndex]));
                dialogueIndex++;
            }
            else
            {
                textComponent.text = ""; // Diyaloglar bitti�inde text'i temizle
            }
        }
    }
    private IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true; // Yazma i�lemi ba�lad�
        textComponent.text = ""; // Text'i temizle

        foreach (char letter in dialogue.ToCharArray())
        {
            textComponent.text += letter; // Harfi ekle

            // Daktilo sesi �al
            if (typingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typingSound, soundVolume);
            }

            yield return new WaitForSeconds(typingSpeed); // Gecikme s�resi
        }

        isTyping = false; // Yazma i�lemi bitti
    }
}
