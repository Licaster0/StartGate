using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenuScript : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Menü panelini buraya atayacaðýz.
    private bool isPaused = false; // Menü durumu
    public GameObject Fullpanel;
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
    
    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true); // Menü panelini aç
        Time.timeScale = 0f; // Oyunu duraklat
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Menü panelini kapat
        Time.timeScale = 1f; // Oyunu devam ettir
        isPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuPanel.gameObject.SetActive(false);
        Canvas.Instance.isSettingsPanelVisible = false;
        Destroy(Fullpanel);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
