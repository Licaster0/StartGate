using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandADrop : MonoBehaviour
{
    private bool isselected;

    // Update is called once per frame
    void Update()
    {
        if (isselected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isselected = false;
        }
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isselected = true;
        }
    }
}
