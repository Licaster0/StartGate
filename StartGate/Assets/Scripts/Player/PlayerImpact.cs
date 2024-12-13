using TMPro;
using UnityEngine;

public class PlayerImpact : MonoBehaviour
{
    public TextMeshProUGUI text;
    private ICollectable currentCollectable;
    public GameObject memoryBookPrefab;
    private void OnTriggerEnter2D(Collider2D col)
    {
        ICollectable Icollectable = col.GetComponent<ICollectable>();
        if (Icollectable != null)
        {
            currentCollectable = Icollectable;
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        ICollectable Icollectable = col.GetComponent<ICollectable>();
        if (Icollectable != null)
        {
            text.enabled = false;
        }
    }
    private void FixedUpdate()
    {


    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && currentCollectable != null)
        {
            currentCollectable.Collect();

            GameObject memoryBook = Instantiate(memoryBookPrefab, transform.position, Quaternion.identity);
            memoryBook.GetComponent<MemoryBook>().Initialize(transform);
        }
    }
}
