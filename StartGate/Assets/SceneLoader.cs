using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float holdDuration = 1.5f;  // Tu�a bas�l� tutulmas� gereken s�re
    private float holdTime = 0f;

    [SerializeField] private Image circularProgress;  // Yuvarlak UI Image referans�

    private void Start()
    {
        if (circularProgress != null)
        {
            circularProgress.fillAmount = 0f;  // Ba�lang��ta doluluk miktar�n� s�f�rla
        }
    }

    private void Update()
    {
        HandleSceneLoading();
    }

    public void NativeLoad()
    {
        SceneManager.LoadScene(1);
    }

    private void HandleSceneLoading()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            holdTime += Time.deltaTime; // Tu�a bas�l� kald�k�a s�reyi art�r
            if (circularProgress != null)
            {
                circularProgress.fillAmount = holdTime / holdDuration; // Daireyi doldur
            }

            if (holdTime >= holdDuration) // Belirtilen s�reyi ge�tikten sonra sahneye ge�i� yap
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            holdTime = 0f; // Tu� b�rak�ld���nda s�reyi s�f�rla
            if (circularProgress != null)
            {
                circularProgress.fillAmount = 0f; // Daireyi s�f�rla
            }
        }
    }
}
