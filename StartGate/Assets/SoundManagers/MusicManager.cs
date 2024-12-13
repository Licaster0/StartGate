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
            DontDestroyOnLoad(gameObject); // Sahne ge�i�lerinde yok olmas�n
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Belirli bir m�zi�i �almaya ba�lar (an�nda).
    /// </summary>
    public void PlayMusic(AudioClip musicClip, float volume = 1f, bool loop = true)
    {
        musicSource.clip = musicClip;
        musicSource.volume = volume;
        musicSource.loop = loop;
        musicSource.Play();
    }

    /// <summary>
    /// M�zi�i fade-in ile ba�lat�r.
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
    /// M�zi�i fade-out ile durdurur.
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
        musicSource.volume = startVolume; // Hacmi geri y�kle
    }

    /// <summary>
    /// M�zi�i durdurur (an�nda).
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }

    /// <summary>
    /// M�zi�i duraklat�r.
    /// </summary>
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    /// <summary>
    /// M�zi�i devam ettirir.
    /// </summary>
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
}
