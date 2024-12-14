using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOpen : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private LekeParts lekeParts;
    private bool isPuzzleOpen = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && lekeParts.cleanedLekes >= lekeParts.totalLekes)
        {
            GameManager.Instance.text.text = "Puzzle'ı Açmak İçin E Tuşuna Bas!";
            isPuzzleOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.text.text = "";
            isPuzzleOpen = false;
        }
    }

    private void Update()
    {
        if (isPuzzleOpen && Input.GetKeyDown(KeyCode.E))
        {
            puzzle.SetActive(true);
            GameManager.Instance.player.moveSpeed = 0;
            GameManager.Instance.text.text = "";
        }

        if (puzzle.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            puzzle.SetActive(false);
            GameManager.Instance.player.moveSpeed = 5;
        }
    }

}
