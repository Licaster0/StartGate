using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenuScript : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Menü panelini buraya atayacaðýz.
    private bool isPaused = false; // Menü durumu

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        // ESC tuþuna basýldýðýnda
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
        pauseMenuPanel.SetActive(true); // Menü panelini aç
        Time.timeScale = 0f; // Oyunu duraklat
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Menü panelini kapat
        Time.timeScale = 1f; // Oyunu devam ettir
        isPaused = false;
    }

}
