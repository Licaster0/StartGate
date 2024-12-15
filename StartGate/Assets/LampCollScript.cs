using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LampCollScript : MonoBehaviour
{
    [SerializeField] GameObject Lamp;
    [SerializeField] GameObject LampDust;
    [SerializeField] GameObject dot1;
    [SerializeField] GameObject dot2;
    [SerializeField] bool Check = false;

    [SerializeField] GameObject puzzleOpen;
    private void Start()
    {
        Lamp.SetActive(false);
        dot1.SetActive(false);
        dot2.SetActive(false);
    }
    private void Update()
    {
        if (Check)
        {
            Check = false;
            puzzleOpen.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Masa"))
        {
            collision.gameObject.SetActive(false);
            Lamp.SetActive(true);
            LampDust.SetActive(true);
            dot1.SetActive(true);
            dot2.SetActive(true);
            Check = true;
            Destroy(gameObject, 5f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public IEnumerator Delay()
    {
        Debug.Log("2");
        yield return new WaitForSeconds(2f);
        GameManager.Instance.fadeScreen.FadeOut();
        GameManager.Instance.CreateBook();
        StartCoroutine(DelayScene());
        Debug.Log("3");
    }
    public IEnumerator DelayScene()
    {
        Debug.Log("1");

        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene(2);
        Debug.Log("4");

    }
}
