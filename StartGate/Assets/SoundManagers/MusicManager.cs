using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne geçiþlerinde yok olmasýn
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Belirli bir müziði çalmaya baþlar (anýnda).
    /// </summary>
    public void PlayMusic(AudioClip musicClip, float volume = 1f, bool loop = true)
    {
        musicSource.clip = musicClip;
        musicSource.volume = volume;
        musicSource.loop = loop;
        musicSource.Play();
    }

    /// <summary>
    /// Müziði fade-in ile baþlatýr.
    /// </summary>
    public IEnumerator FadeInMusic(AudioClip musicClip, float duration, float targetVolume, bool loop = true)
    {
        musicSource.clip = musicClip;
        musicSource.volume = 0;
        musicSource.loop = loop;
        musicSource.Play();

        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            musicSource.volume = Mathf.Lerp(0, targetVolume, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        musicSource.volume = targetVolume;
    }

    /// <summary>
    /// Müziði fade-out ile durdurur.
    /// </summary>
    public IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = musicSource.volume;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume; // Hacmi geri yükle
    }

    /// <summary>
    /// Müziði durdurur (anýnda).
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }

    /// <summary>
    /// Müziði duraklatýr.
    /// </summary>
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    /// <summary>
    /// Müziði devam ettirir.
    /// </summary>
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
}
