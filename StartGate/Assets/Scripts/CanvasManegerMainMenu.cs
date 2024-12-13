using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Canvas : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    
    private void CreditGame()
    {

    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
