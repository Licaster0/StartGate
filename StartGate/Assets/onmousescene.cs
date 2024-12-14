using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class onmousescene : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("puzzle2");
    }
}
