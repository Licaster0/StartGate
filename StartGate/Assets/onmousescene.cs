using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onmousescene : MonoBehaviour
{
    public string scenename;
    private void OnMouseDown()
    {
        SceneManager.LoadScene("puzzle2");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
