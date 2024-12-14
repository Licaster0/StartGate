using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    [SerializeField] private GameObject creditAnimation;
    [SerializeField] private CanvasGroup creditPanel;
    [SerializeField] private float fadeDuration = 0.5f; 
    [SerializeField] private bool isPanelVisible = false;
    [SerializeField] private bool isSettingsPanelVisible = false;
    [SerializeField] private CanvasGroup settingsPanel;
    private void Start()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void ToggleCreditPanel()
    {
        if (isPanelVisible)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            StartCoroutine(FadeIn());
        }

        isPanelVisible = !isPanelVisible;
    }

    public void ToggleSettingsPanel()
    {
        if (isSettingsPanelVisible)
        {
            StartCoroutine(SettingsFadeOut());
        }
        else
        {
            StartCoroutine(SettingsFadeIn());
        }

        isSettingsPanelVisible = !isSettingsPanelVisible;
    }
    private IEnumerator SettingsFadeIn()
    {
        settingsPanel.gameObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            settingsPanel.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        settingsPanel.alpha = 1f;
    }

    private IEnumerator SettingsFadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            settingsPanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        settingsPanel.alpha = 0f;
        settingsPanel.gameObject.SetActive(false);
    }
    private IEnumerator FadeIn()
    {
        creditPanel.gameObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            creditPanel.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        creditPanel.alpha = 1f;
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            creditPanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        creditPanel.alpha = 0f;
        creditPanel.gameObject.SetActive(false); 
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
