using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    public static SoundEffectManager Instance;

    [SerializeField] private AudioSource soundEffectObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFxClip(AudioClip audioClip, Transform spawnTransform, float volume, bool randomizePitch = false)
    {
        AudioSource audioSource = Instantiate(soundEffectObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;

        // Eðer rastgele pitch isteniyorsa, deðer ayarla
        if (randomizePitch)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
        }

        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
    public void PlayRandomSoundFxClip(AudioClip[] audioClips, Transform spawnTransform, float volume, bool randomizePitch = false)
    {
        int rand = Random.Range(0, audioClips.Length);

        AudioSource audioSource = Instantiate(soundEffectObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClips[rand];
        audioSource.volume = volume;

        // Eðer rastgele pitch isteniyorsa, deðer ayarla
        if (randomizePitch)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
        }

        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
