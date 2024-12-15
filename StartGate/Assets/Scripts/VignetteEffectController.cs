using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class VignetteEffectController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // Post-process Volume nesnesini buraya ba�lay�n.
   [Range(1,30)] public float time;
    private Vignette vignette;

    private void Start()
    {
        // Vignette efektine eri�im
        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            StartCoroutine(SmoothVignetteEffect(0.25f, 1f, time)); // 2 saniyede smooth ge�i�
        }
        else
        {
            Debug.LogWarning("Vignette efekti bulunamad�!");
        }
    }

    private IEnumerator SmoothVignetteEffect(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;

        // Ge�i� boyunca intensity de�erini de�i�tirme
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // �lerleme oran�
            vignette.intensity.Override(Mathf.Lerp(startValue, endValue, t));
            yield return null;
            
        }
        SceneManager.LoadScene(0);

        // Son de�eri garantiye al
        vignette.intensity.Override(endValue);
    }
}
