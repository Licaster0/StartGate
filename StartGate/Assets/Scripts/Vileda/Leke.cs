using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Leke : MonoBehaviour
{
    [SerializeField] private int currentPaper = 0;
    [SerializeField] private int scenePaperCount;
    [SerializeField] private bool canFinish;
    private void Start()
    {
        canFinish = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Leke"))
        {
            collision.gameObject.SetActive(false);
            currentPaper++;
            if (currentPaper == scenePaperCount)
            {
                canFinish = true;
            }
        }
        if (canFinish)
        {
            SceneManager.LoadScene(2);
        }
    }

}
