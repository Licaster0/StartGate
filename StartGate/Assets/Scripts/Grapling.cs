using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [Header("Grappling Settings")]
    public LineRenderer lineRenderer; // Halat çizgisi
    public Transform hookPoint;      // Halatýn fýrlatýlacaðý nokta (karakterden çýkýþ noktasý)
    public LayerMask grappleLayer;   // Baðlanýlabilir noktalar için Layer
    public float maxDistance = 15f;  // Halatýn maksimum mesafesi
    public float pullForce = 20f;    // Çekme kuvveti
    public float swingForce = 15f;   // Sallanma kuvveti

    [Header("Visual Settings")]
    public Color ropeColor = Color.white; // Halat rengi
    public float ropeThickness = 0.1f;   // Halat kalýnlýðý

    private Vector2 grapplePosition;     // Baðlanýlan nokta
    private bool isGrappling = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetupLineRenderer();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol týkla halatý fýrlat
        {
            TryGrapple();
        }

        if (Input.GetMouseButtonUp(0)) // Sol týký býrakýnca halatý býrak
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

            if (distance > 0.5f) // Hedefe yeterince yaklaþmadýysa çek
            {
                ApplyGrappleForce();
            }
            else
            {
                StopGrappling(); // Hedefe ulaþtýysa dur
            }
        }
    }

    private void SetupLineRenderer()
    {
        lineRenderer.startColor = ropeColor;
        lineRenderer.endColor = ropeColor;
        lineRenderer.startWidth = ropeThickness;
        lineRenderer.endWidth = ropeThickness;
        lineRenderer.positionCount = 0; // Halat baþlangýçta görünmez
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

            lineRenderer.positionCount = 2; // Halatý etkinleþtir
        }
    }

    private void StopGrappling()
    {
        isGrappling = false;
        lineRenderer.positionCount = 0; // Halatý görünmez yap
    }

    private void DrawRope()
    {
        lineRenderer.SetPosition(0, hookPoint.position);
        lineRenderer.SetPosition(1, grapplePosition);
    }

    private void ApplyGrappleForce()
    {
        // Çekme yönü: Baðlanma noktasýna doðru normalize edilmiþ vektör
        Vector2 direction = (grapplePosition - (Vector2)transform.position).normalized;

        // Çekme kuvveti uygulama
        rb.velocity = direction * pullForce;

        // Eðer sallanma istiyorsan ekle
        if (Input.GetKey(KeyCode.A)) // Sol sallanma
        {
            rb.AddForce(Vector2.left * swingForce);
        }
        else if (Input.GetKey(KeyCode.D)) // Sað sallanma
        {
            rb.AddForce(Vector2.right * swingForce);
        }
    }

}
