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
    [SerializeField] public bool sifreDoru;
    [SerializeField] private bool Check = false;
    [SerializeField] private GameObject NumberBox;
    [SerializeField] private GameObject Number1;
    [SerializeField] private GameObject Number2;
    [SerializeField] private GameObject Number3;
    [SerializeField] private GameObject Number4;
    private void Start()
    {
        canFinish = false;
        sifreDoru = false;
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
            if (currentPaper == 1)
            {
                Number1.SetActive(true);
            }
            else if (currentPaper == 2)
            {
                Number2.SetActive(true);
            }
            else if (currentPaper == 3)
            {
                Number3.SetActive(true);
            }
            else if (currentPaper == 4)
            {
                Number4.SetActive(true);
            }
            if (currentPaper == scenePaperCount)
            {
                canFinish = true;
            }
        }
        if (collision.gameObject.CompareTag("Finishh") && canFinish)
        {
            NumberBox.SetActive(true);
            gameObject.GetComponent<PlayerMovementPlatformer>().enabled = false;
            gameObject.GetComponent<GrapplingHook>().enabled = false;
            gameObject.GetComponent<FootSteps>().enabled = false;
            //collision.gameObject.SetActive(false);
            //Check = true;
            //Destroy(gameObject, 5f);
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.fadeScreen.FadeOut();
        StartCoroutine(DelayScene());
    }
    public IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
    public void CreateBook()
    {
        PlayerImpact playerImpact = GameManager.Instance.player.GetComponent<PlayerImpact>();
        playerImpact.CreateBook();
    }
}
