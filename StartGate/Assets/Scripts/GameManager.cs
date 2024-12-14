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

    public int nextSceneIndex;
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
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CreateBook();
        }
    }

    public void CreateBook()
    {
        PlayerImpact _player = player.GetComponent<PlayerImpact>();
        _player.CreateBook();
    }
}
