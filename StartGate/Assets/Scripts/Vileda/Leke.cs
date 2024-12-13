using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leke : MonoBehaviour
{
    [SerializeField] private Vileda vileda;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("X.");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Y.");
                if (vileda.collectedPartsCount == vileda.parts.Length)
                {
                    Debug.Log("Z.");
                    gameObject.SetActive(false);
                    GameManager.Instance.text.text = "Stain cleaned!";
                }
                else
                {
                    GameManager.Instance.text.text = "You need to collect all parts to clean the stain.";
                }
            }
        }
    }
}
