using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    public InputField inputField;  // Kullan�c�n�n girdi�i �ifreyi g�sterecek.
    public Text statusText;       // Durum mesajlar�n� g�sterecek.
    public string correctPassword = "1234"; // Do�ru �ifre.

    private string enteredPassword = ""; // Kullan�c�n�n girdi�i �ifre.

    // Tu�lara bas�ld���nda �a�r�l�r.
    public void OnNumberButtonClick(string number)
    {
        if (enteredPassword.Length < 10) // Maksimum 10 karakter.
        {
            enteredPassword += number;
            inputField.text = enteredPassword; // �ifreyi ekranda g�ster.
        }
    }

    // "OK" butonuna bas�ld���nda �a�r�l�r.
    public void OnOkButtonClick()
    {
        if (enteredPassword == correctPassword)
        {
            statusText.text = "Sifre dogru! Yeni levele geciyorsunuz.";
            // Yeni levele ge�mek i�in i�lemler burada yap�labilir.
            LoadNextLevel();
        }
        else
        {
            statusText.text = "Sifre yanlis! Tekrar deneyin.";
            enteredPassword = "";
            inputField.text = ""; // InputField'� temizle.
        }
    }

    // "Clear" butonuna bas�ld���nda �a�r�l�r.
    public void OnClearButtonClick()
    {
        enteredPassword = "";
        inputField.text = ""; // InputField'� temizle.
    }

    private void LoadNextLevel()
    {
        // Yeni sahneyi y�kleme i�lemi.
        // �rne�in: SceneManager.LoadScene("NextLevelSceneName");
    }
}
