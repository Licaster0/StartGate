using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;

public class SlotMachineGame : MonoBehaviour
{
    public string[] words = { "king", "gardýrop" }; // Tahmin edilecek kelimeler
    private string currentWord; // Þu anda tahmin edilen kelime
    private int currentLetterIndex = 0; // Þu anda doðru harfi bulmamýz gereken index
    private bool isSlotActive = false;
    private bool isGameOver = false;

    public TextMeshProUGUI[] slots; // TMP Slotlar dizisi
    public float spinSpeed = 0.1f; // Harflerin dönme hýzý
    private Coroutine[] spinCoroutines;
    private string currentAlphabet; // O anki kelimenin harflerinden oluþan alfabetik dizi

    void Start()
    {
        spinCoroutines = new Coroutine[slots.Length];
        SetNewWord(); // Yeni bir kelime ayarla
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            // Þu anki karakteri durdur
            StopSlot();
        }
    }

    void SetNewWord()
    {
        // Yeni kelimeyi seç
        currentWord = words[Random.Range(0, words.Length)];
        currentLetterIndex = 0; // Baþlangýç index'i sýfýrla
        currentAlphabet = new string(currentWord.Distinct().ToArray()); // Kelimedeki benzersiz harfleri al
        isSlotActive = false; // Slotlarý durdur
        StartSlot(); // Yeni kelimeyle slotlarý baþlat
    }

    void StartSlot()
    {
        // Eðer oyun bitmediyse slotlarý baþlat
        if (isGameOver) return;

        isSlotActive = true;
        // Her bir slotu döndürmeye baþla
        for (int i = 0; i < slots.Length; i++)
        {
            spinCoroutines[i] = StartCoroutine(RotateSlot(slots[i], i));
        }
    }

    IEnumerator RotateSlot(TextMeshProUGUI slot, int index)
    {
        while (isSlotActive && index == currentLetterIndex)
        {
            slot.text = GetRandomLetter(); // Slotta rastgele harf göster
            yield return new WaitForSeconds(spinSpeed); // Harflerin ne kadar süreyle döneceðini belirle
        }
    }

    void StopSlot()
    {
        // Eðer geçerli slot doðru harfi gösteriyorsa bir sonraki harfe geç
        if (slots[currentLetterIndex].text == currentWord[currentLetterIndex].ToString())
        {
            Debug.Log("Doðru harf: " + slots[currentLetterIndex].text);
            currentLetterIndex++; // Bir sonraki harfe geç

            // Eðer kelimenin sonuna geldiysen oyun bitmiþtir
            if (currentLetterIndex >= currentWord.Length)
            {
                isGameOver = true;
                Debug.Log("Kelimeyi doðru tahmin ettiniz!");
                // 2 saniye sonra yeni kelimeye geçiþ
                Invoke("SetNewWord", 2f);
                return;
            }

            // Yeni slotu döndürmeye baþla
            StartSlot();
        }
        else
        {
            Debug.Log("Yanlýþ harf! Tekrar deneyin.");
            // Eðer yanlýþ harfse, mevcut slotu tekrar döndür
            StartCoroutine(RotateSlot(slots[currentLetterIndex], currentLetterIndex));
        }
    }

    string GetRandomLetter()
    {
        // O anki kelimenin harflerinden rastgele bir harf döndür
        return currentAlphabet[Random.Range(0, currentAlphabet.Length)].ToString();
    }
}
