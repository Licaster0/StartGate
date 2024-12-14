using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject lampLight;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Knife_Controller>() != null)
        {
            lampLight.AddComponent<Rigidbody2D>();
            Destroy(gameObject);
        }
    }
}
