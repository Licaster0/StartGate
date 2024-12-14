using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    private bool isPuzzleSolved = false;
    private bool isBookOpen = false;

    [SerializeField] private GameObject puzzle;

    [Header("Parts")]
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject p3;
    [SerializeField] private GameObject p4;
    [SerializeField] private GameObject p5;

    [Header("End Positions")]
    [SerializeField] private Transform p1pos;
    [SerializeField] private Transform p2pos;
    [SerializeField] private Transform p3pos;
    [SerializeField] private Transform p4pos;
    [SerializeField] private Transform p5pos;

    [Header("Starting Positions")]
    [SerializeField] private Transform firstPos;
    [SerializeField] private Transform secondPos;
    [SerializeField] private Transform thirdPos;
    [SerializeField] private Transform fourthPos;
    [SerializeField] private Transform fifthPos;

    public void RestartScene()
    {
        p1.transform.position = firstPos.position;
        p2.transform.position = secondPos.position;
        p3.transform.position = thirdPos.position;
        p4.transform.position = fourthPos.position;
        p5.transform.position = fifthPos.position;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarting scene...");
            RestartScene();
        }
        if (!isPuzzleSolved && p1.transform.position == p1pos.position && p2.transform.position == p2pos.position && p3.transform.position == p3pos.position && p4.transform.position == p4pos.position && p5.transform.position == p5pos.position)
        {
            isPuzzleSolved = true;
        }

        if (isPuzzleSolved && !isBookOpen)
        {
            isBookOpen = true;
            GameManager.Instance.CreateBook();
            GameManager.Instance.player.moveSpeed = 5;
            GameManager.Instance.text.text = "Puzzle Solved! Gate is open!";
            puzzle.SetActive(false);
        }
    }
}
