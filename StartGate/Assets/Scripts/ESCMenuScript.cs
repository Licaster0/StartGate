using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenuScript : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Men� panelini buraya atayaca��z.
    private bool isPaused = false; // Men� durumu

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        // ESC tu�una bas�ld���nda
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainScreen")
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    void PauseGame()
    {
        pauseMenuPanel.SetActive(true); // Men� panelini a�
        Time.timeScale = 0f; // Oyunu duraklat
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Men� panelini kapat
        Time.timeScale = 1f; // Oyunu devam ettir
        isPaused = false;
    }

}
