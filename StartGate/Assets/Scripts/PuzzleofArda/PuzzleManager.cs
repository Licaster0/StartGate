using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public Transform p1pos;
    public Transform p2pos;
    public Transform p3pos;
    public Transform p4pos;
    public Transform p5pos;

    private void Update()
    {
        if (p1.transform.position == p1pos.position && p2.transform.position == p2pos.position && p3.transform.position == p3pos.position && p4.transform.position == p4pos.position && p5.transform.position == p5pos.position)
        {
            Debug.Log("Puzzle tamamlandı");
        }
    }





}
