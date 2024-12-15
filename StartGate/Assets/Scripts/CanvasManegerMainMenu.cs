using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    public static Canvas Instance;

    [SerializeField] private GameObject creditAnimation;
    [SerializeField] private CanvasGroup creditPanel;
    [SerializeField] private float fadeDuration = 0.5f; 
    [SerializeField] private bool isPanelVisible = false;
    public bool isSettingsPanelVisible = false;
    [SerializeField] private CanvasGroup settingsPanel;
    // CanvasGroup bileþeni referansý
    private CanvasGroup canvasGroup;

    // Fade süresi
    [SerializeField] private float fadeDuration0 = 1.5f;

    private void Start()
    {
        // CanvasGroup bileþenini al
        canvasGroup = GetComponent<CanvasGroup>();

        // Baþlangýçta tamamen görünmez yap
        canvasGroup.alpha = 0f;

        // Fade In baþlat
        StartCoroutine(FadeInScene());
    }

    private IEnumerator FadeInScene()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration0)
        {
            // Alpha deðerini zamanla 0'dan 1'e çýkar
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration0);

            // Geçen süreyi artýr
            elapsedTime += Time.deltaTime;

            // Bir frame bekle
            yield return null;
        }

        // Fade tamamlandýðýnda alpha deðerini tam görünür olarak ayarla
        canvasGroup.alpha = 1f;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        settingsPanel.gameObject.SetActive(false);
        creditPanel.gameObject.SetActive(false);
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
