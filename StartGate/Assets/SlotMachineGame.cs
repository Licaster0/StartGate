using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;

public class SlotMachineGame : MonoBehaviour
{
    public string[] words = { "king", "gard�rop" }; // Tahmin edilecek kelimeler
    private string currentWord; // �u anda tahmin edilen kelime
    private int currentLetterIndex = 0; // �u anda do�ru harfi bulmam�z gereken index
    private bool isSlotActive = false;
    private bool isGameOver = false;

    public TextMeshProUGUI[] slots; // TMP Slotlar dizisi
    public float spinSpeed = 0.1f; // Harflerin d�nme h�z�
    private Coroutine[] spinCoroutines;
    private string currentAlphabet; // O anki kelimenin harflerinden olu�an alfabetik dizi

    void Start()
    {
        spinCoroutines = new Coroutine[slots.Length];
        SetNewWord(); // Yeni bir kelime ayarla
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            // �u anki karakteri durdur
            StopSlot();
        }
    }

    void SetNewWord()
    {
        // Yeni kelimeyi se�
        currentWord = words[Random.Range(0, words.Length)];
        currentLetterIndex = 0; // Ba�lang�� index'i s�f�rla
        currentAlphabet = new string(currentWord.Distinct().ToArray()); // Kelimedeki benzersiz harfleri al
        isSlotActive = false; // Slotlar� durdur
        StartSlot(); // Yeni kelimeyle slotlar� ba�lat
    }

    void StartSlot()
    {
        // E�er oyun bitmediyse slotlar� ba�lat
        if (isGameOver) return;

        isSlotActive = true;
        // Her bir slotu d�nd�rmeye ba�la
        for (int i = 0; i < slots.Length; i++)
        {
            spinCoroutines[i] = StartCoroutine(RotateSlot(slots[i], i));
        }
    }

    IEnumerator RotateSlot(TextMeshProUGUI slot, int index)
    {
        while (isSlotActive && index == currentLetterIndex)
        {
            slot.text = GetRandomLetter(); // Slotta rastgele harf g�ster
            yield return new WaitForSeconds(spinSpeed); // Harflerin ne kadar s�reyle d�nece�ini belirle
        }
    }

    void StopSlot()
    {
        // E�er ge�erli slot do�ru harfi g�steriyorsa bir sonraki harfe ge�
        if (slots[currentLetterIndex].text == currentWord[currentLetterIndex].ToString())
        {
            Debug.Log("Do�ru harf: " + slots[currentLetterIndex].text);
            currentLetterIndex++; // Bir sonraki harfe ge�

            // E�er kelimenin sonuna geldiysen oyun bitmi�tir
            if (currentLetterIndex >= currentWord.Length)
            {
                isGameOver = true;
                Debug.Log("Kelimeyi do�ru tahmin ettiniz!");
                // 2 saniye sonra yeni kelimeye ge�i�
                Invoke("SetNewWord", 2f);
                return;
            }

            // Yeni slotu d�nd�rmeye ba�la
            StartSlot();
        }
        else
        {
            Debug.Log("Yanl�� harf! Tekrar deneyin.");
            // E�er yanl�� harfse, mevcut slotu tekrar d�nd�r
            StartCoroutine(RotateSlot(slots[currentLetterIndex], currentLetterIndex));
        }
    }

    string GetRandomLetter()
    {
        // O anki kelimenin harflerinden rastgele bir harf d�nd�r
        return currentAlphabet[Random.Range(0, currentAlphabet.Length)].ToString();
    }
}
