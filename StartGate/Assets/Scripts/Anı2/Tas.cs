using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tas : MonoBehaviour
{
    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LampLight")
        {
            isTriggered = true;
            
        }
    }

    private void Update()
    {
        if (isTriggered)
        {

        }
    }
}
