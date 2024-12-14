using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenuScript : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Men� panelini buraya atayaca��z.
    private bool isPaused = false; // Men� durumu
    public GameObject Fullpanel;
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
    
    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true); // Men� panelini a�
        Time.timeScale = 0f; // Oyunu duraklat
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Men� panelini kapat
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
