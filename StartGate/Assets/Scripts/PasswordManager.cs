using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    public InputField inputField;  // Kullanýcýnýn girdiði þifreyi gösterecek.
    public Text statusText;       // Durum mesajlarýný gösterecek.
    public string correctPassword = "1234"; // Doðru þifre.

    private string enteredPassword = ""; // Kullanýcýnýn girdiði þifre.

    // Tuþlara basýldýðýnda çaðrýlýr.
    public void OnNumberButtonClick(string number)
    {
        if (enteredPassword.Length < 10) // Maksimum 10 karakter.
        {
            enteredPassword += number;
            inputField.text = enteredPassword; // Þifreyi ekranda göster.
        }
    }

    // "OK" butonuna basýldýðýnda çaðrýlýr.
    public void OnOkButtonClick()
    {
        if (enteredPassword == correctPassword)
        {
            statusText.text = "Þifre doðru! Level geçti.";
            // Yeni levele geçmek için iþlemler burada yapýlabilir.
            LoadNextLevel();
        }
        else
        {
            statusText.text = "Yanlýþ þifre! Tekrar deneyin.";
            enteredPassword = "";
            inputField.text = ""; // InputField'ý temizle.
        }
    }

    // "Clear" butonuna basýldýðýnda çaðrýlýr.
    public void OnClearButtonClick()
    {
        enteredPassword = "";
        inputField.text = ""; // InputField'ý temizle.
    }

    private void LoadNextLevel()
    {
        // Yeni sahneyi yükleme iþlemi.
        // Örneðin: SceneManager.LoadScene("NextLevelSceneName");
    }
}
