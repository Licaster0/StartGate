using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform target; 
    public Vector2 minBounds; 
    public Vector2 maxBounds; 
    public float smoothSpeed = 0.125f; 

    private Vector3 targetPosition;

    void LateUpdate()
    {
        if (target != null)
        {
            
            targetPosition = target.position;

            
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
