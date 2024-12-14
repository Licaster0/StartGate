using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    [SerializeField] private AudioSource FootSteepss;
    [SerializeField] private AudioClip footstep;
    public void FootSteeps()
    {
        FootSteepss.PlayOneShot(footstep); // Footstep sesini bir kez çal
    }
}
