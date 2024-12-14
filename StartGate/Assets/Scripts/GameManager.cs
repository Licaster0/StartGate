using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerMovement player;
    public UI_FadeScreen fadeScreen;
    public TextMeshProUGUI text;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator ChangeScene(int sceneIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneIndex);
    }
}
