using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhonesManager : MonoBehaviour
{
    [SerializeField] private int currentPaper = 0;
    [SerializeField] private int scenePaperCount;
    [SerializeField] private bool canFinish;
    [SerializeField] private bool Check = false;
    private void Start()
    {
        canFinish = false;
    }
    private void Update()
    {
        if (Check)
        {
            Check = false;
            StartCoroutine(Delay());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Papers"))
        {
            collision.gameObject.SetActive(false);
            currentPaper++;
            if (currentPaper == scenePaperCount)
            {
                canFinish = true;
            }
        }
        if (collision.gameObject.CompareTag("Finishh") && canFinish)
        {
            collision.gameObject.SetActive(false);
            Check = true;
            Destroy(gameObject, 5f);
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.fadeScreen.FadeOut();
        CreateBook();
        StartCoroutine(DelayScene());
    }
    public IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene(2);
    }
    public void CreateBook()
    {
        PlayerImpact playerImpact = GameManager.Instance.player.GetComponent<PlayerImpact>();
        playerImpact.CreateBook();
    }
}
