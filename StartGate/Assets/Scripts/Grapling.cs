using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [Header("Grappling Settings")]
    public LineRenderer lineRenderer; // Halat �izgisi
    public Transform hookPoint;      // Halat�n f�rlat�laca�� nokta (karakterden ��k�� noktas�)
    public LayerMask grappleLayer;   // Ba�lan�labilir noktalar i�in Layer
    public float maxDistance = 15f;  // Halat�n maksimum mesafesi
    public float pullForce = 20f;    // �ekme kuvveti
    public float swingForce = 15f;   // Sallanma kuvveti

    [Header("Visual Settings")]
    public Color ropeColor = Color.white; // Halat rengi
    public float ropeThickness = 0.1f;   // Halat kal�nl���

    private Vector2 grapplePosition;     // Ba�lan�lan nokta
    private bool isGrappling = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetupLineRenderer();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol t�kla halat� f�rlat
        {
            TryGrapple();
        }

        if (Input.GetMouseButtonUp(0)) // Sol t�k� b�rak�nca halat� b�rak
        {
            StopGrappling();
        }

        if (isGrappling)
        {
            DrawRope();
        }
    }

    private void FixedUpdate()
    {
        if (isGrappling)
        {
            float distance = Vector2.Distance(transform.position, grapplePosition);

            if (distance > 0.5f) // Hedefe yeterince yakla�mad�ysa �ek
            {
                ApplyGrappleForce();
            }
            else
            {
                StopGrappling(); // Hedefe ula�t�ysa dur
            }
        }
    }

    private void SetupLineRenderer()
    {
        lineRenderer.startColor = ropeColor;
        lineRenderer.endColor = ropeColor;
        lineRenderer.startWidth = ropeThickness;
        lineRenderer.endWidth = ropeThickness;
        lineRenderer.positionCount = 0; // Halat ba�lang��ta g�r�nmez
    }

    private void TryGrapple()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)hookPoint.position;

        RaycastHit2D hit = Physics2D.Raycast(hookPoint.position, direction, maxDistance, grappleLayer);

        if (hit.collider != null)
        {
            isGrappling = true;
            grapplePosition = hit.point;

            lineRenderer.positionCount = 2; // Halat� etkinle�tir
        }
    }

    private void StopGrappling()
    {
        isGrappling = false;
        lineRenderer.positionCount = 0; // Halat� g�r�nmez yap
    }

    private void DrawRope()
    {
        lineRenderer.SetPosition(0, hookPoint.position);
        lineRenderer.SetPosition(1, grapplePosition);
    }

    private void ApplyGrappleForce()
    {
        // �ekme y�n�: Ba�lanma noktas�na do�ru normalize edilmi� vekt�r
        Vector2 direction = (grapplePosition - (Vector2)transform.position).normalized;

        // �ekme kuvveti uygulama
        rb.velocity = direction * pullForce;

        // E�er sallanma istiyorsan ekle
        if (Input.GetKey(KeyCode.A)) // Sol sallanma
        {
            rb.AddForce(Vector2.left * swingForce);
        }
        else if (Input.GetKey(KeyCode.D)) // Sa� sallanma
        {
            rb.AddForce(Vector2.right * swingForce);
        }
    }

}
