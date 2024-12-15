using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject puzzle;
    private bool isPussleSolved;
    private bool isBookOpen;
    public GameObject k1;
    public GameObject k2;
    public GameObject k3;
    public GameObject k4;
    public GameObject k5;
    public GameObject k6;
    public GameObject k7;
    public GameObject k8;
    public GameObject k9;
    public Transform k1pos;
    public Transform k2pos;
    public Transform k3pos;
    public Transform k4pos;
    public Transform k5pos;
    public Transform k6pos;
    public Transform k7pos;
    public Transform k8pos;
    public Transform k9pos;
    void Update()
    {
        if (!isPussleSolved && k1.transform.position == k1pos.position && k2.transform.position == k2pos.position && k3.transform.position == k3pos.position && k4.transform.position == k4pos.position && k5.transform.position == k5pos.position && k6.transform.position == k6pos.position && k7.transform.position == k7pos.position && k8.transform.position == k8pos.position && k9.transform.position == k9pos.position)
        {
            isPussleSolved = true;
        }

        if (isPussleSolved && !isBookOpen)
        {
            isBookOpen = true;
            GameManager.Instance.CreateBook();
            GameManager.Instance.player.moveSpeed = 5;
            GameManager.Instance.text.text = "Puzzle Solved! Gate is open!";
            puzzle.SetActive(false);
        }
    }
}
