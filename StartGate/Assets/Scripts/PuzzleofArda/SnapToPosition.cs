using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour 
{
    
    public Transform targetPosition; // Doğru yerleşim noktası
    public float snapDistance = 0.5f; // Hedefe yakınlık eşiği
    

    private bool isPlaced = false;
    

    private void Update()
    {
        if (!isPlaced && Vector3.Distance(transform.position, targetPosition.position) < snapDistance)
        {
            transform.position = targetPosition.position; // Parçayı hedefe sabitle
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;  
        }
        
    }
   
}
