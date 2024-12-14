using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Leke : MonoBehaviour
{
    [SerializeField] private Vileda vileda;
    [SerializeField] private ParticleSystem freshFx;

    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (vileda.collectedPartsCount == vileda.parts.Length)
            {
                isCollected = true;
                GameManager.Instance.text.text = "Press E to pick up this part.";
            }
            else
            {
                isCollected = false;
                GameManager.Instance.text.text = "You need to collect all parts first.";
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollected)
        {
            freshFx.Play();
            PlayerReferences();
            GameManager.Instance.StartCoroutine(GameManager.Instance.ChangeScene(1));
            Destroy(gameObject);
            GameManager.Instance.text.text = "";
        }
    }

    private void PlayerReferences()
    {
        PlayerImpact playerImpact = GameManager.Instance.player.GetComponent<PlayerImpact>();
        playerImpact.CreateBook();
    }
}
