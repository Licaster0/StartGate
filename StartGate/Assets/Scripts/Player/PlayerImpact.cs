using TMPro;
using UnityEngine;

public class PlayerImpact : MonoBehaviour
{
    public TextMeshProUGUI text;
    private ICollectable currentCollectable;
    public GameObject memoryBookPrefab;
    [SerializeField] private Transform bookTransform;
    private void OnTriggerEnter2D(Collider2D col)
    {
        ICollectable Icollectable = col.GetComponent<ICollectable>();
        if (Icollectable != null)
        {
            currentCollectable = Icollectable;
            text.enabled = true;
            text.text = "Etkilesim icin E tusuna basin";
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        ICollectable Icollectable = col.GetComponent<ICollectable>();
        if (Icollectable != null)
        {
            currentCollectable = null;
            if(text != null)
            {
                text.enabled = false;
            }
          

        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && currentCollectable != null)
        {
            currentCollectable.Collect();
            GameManager.Instance.fadeScreen.FadeOut();
            CreateBook();
        }
    }

    public void CreateBook()
    {
        GameObject memoryBook = Instantiate(memoryBookPrefab, bookTransform.position, Quaternion.identity);
    }
}
