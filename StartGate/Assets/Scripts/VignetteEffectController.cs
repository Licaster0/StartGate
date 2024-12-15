using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class VignetteEffectController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // Post-process Volume nesnesini buraya baðlayýn.
   [Range(1,30)] public float time;
    private Vignette vignette;

    private void Start()
    {
        // Vignette efektine eriþim
        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            StartCoroutine(SmoothVignetteEffect(0.25f, 1f, time)); // 2 saniyede smooth geçiþ
        }
        else
        {
            Debug.LogWarning("Vignette efekti bulunamadý!");
        }
    }

    private IEnumerator SmoothVignetteEffect(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;

        // Geçiþ boyunca intensity deðerini deðiþtirme
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Ýlerleme oraný
            vignette.intensity.Override(Mathf.Lerp(startValue, endValue, t));
            yield return null;
            
        }
        SceneManager.LoadScene(0);

        // Son deðeri garantiye al
        vignette.intensity.Override(endValue);
    }
}
