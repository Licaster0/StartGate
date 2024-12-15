using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOpen : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private LekeParts lekeParts;
    private bool isPuzzleOpen = false;
    [SerializeField] private GameObject Tringle;
    [SerializeField] private PuzzleManager puzzleManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && lekeParts.cleanedLekes >= lekeParts.totalLekes)
        {
            GameManager.Instance.text.text = "Puzzle'i Acmak Icin E Tusuna Bas!";
            isPuzzleOpen = true;
            Tringle.SetActive(true);
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
        if (!puzzleManager.isBookOpen && isPuzzleOpen && Input.GetKeyDown(KeyCode.E))
        {
            puzzle.SetActive(true);
            GameManager.Instance.player.moveSpeed = 0;
            GameManager.Instance.text.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            puzzle.SetActive(false);
            GameManager.Instance.player.moveSpeed = 5;
        }
    }

}
