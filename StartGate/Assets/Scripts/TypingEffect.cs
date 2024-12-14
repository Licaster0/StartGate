using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    [Header("Text Ayarlarý")]
    public TextMeshProUGUI textComponent; // UI TextMeshPro Text
    public string[] dialogues; // Diyaloglarýn listesi
    public float typingSpeed = 0.05f; // Daktilo yazma hýzý

    [Header("Ses Ayarlarý")]
    public AudioSource audioSource; // Daktilo sesi için AudioSource
    public AudioClip typingSound; // Daktilo sesi
    [Range(0f, 1f)] public float soundVolume = 0.3f; // Ses seviyesi

    private int dialogueIndex = 0; // Þu anki diyalog indeksi
    private bool isTyping = false; // Yazma iþlemi kontrolü

    void Start()
    {
        textComponent.text = ""; // Ýlk baþta boþ býrak
    }

    void Update()
    {
        // E tuþuna basýldýðýnda bir sonraki diyalogu göster
        if (Input.GetKeyDown(KeyCode.E) && !isTyping)
        {
            if (dialogueIndex < dialogues.Length)
            {
                StartCoroutine(TypeDialogue(dialogues[dialogueIndex]));
                dialogueIndex++;
            }
            else
            {
                textComponent.text = ""; // Diyaloglar bittiðinde text'i temizle
            }
        }
    }
    private IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true; // Yazma iþlemi baþladý
        textComponent.text = ""; // Text'i temizle

        foreach (char letter in dialogue.ToCharArray())
        {
            textComponent.text += letter; // Harfi ekle

            // Daktilo sesi çal
            if (typingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typingSound, soundVolume);
            }

            yield return new WaitForSeconds(typingSpeed); // Gecikme süresi
        }

        isTyping = false; // Yazma iþlemi bitti
    }
}
