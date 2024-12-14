using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform target; // Kamera hangi nesneyi takip edecek
    public Vector2 minBounds; // Minimum sýnýr (sol-alt köþe)
    public Vector2 maxBounds; // Maksimum sýnýr (sað-üst köþe)
    public float smoothSpeed = 0.125f; // Kameranýn yumuþak hareket etme hýzý

    private Vector3 targetPosition;

    void LateUpdate()
    {
        if (target != null)
        {
            // Takip edilecek nesnenin pozisyonunu al
            targetPosition = target.position;

            // Pozisyonu sýnýrlar içinde tut
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

            // Kameranýn pozisyonunu yumuþak bir þekilde deðiþtir
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
