using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform target; // Kamera hangi nesneyi takip edecek
    public Vector2 minBounds; // Minimum s�n�r (sol-alt k��e)
    public Vector2 maxBounds; // Maksimum s�n�r (sa�-�st k��e)
    public float smoothSpeed = 0.125f; // Kameran�n yumu�ak hareket etme h�z�

    private Vector3 targetPosition;

    void LateUpdate()
    {
        if (target != null)
        {
            // Takip edilecek nesnenin pozisyonunu al
            targetPosition = target.position;

            // Pozisyonu s�n�rlar i�inde tut
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

            // Kameran�n pozisyonunu yumu�ak bir �ekilde de�i�tir
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
