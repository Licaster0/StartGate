using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4CanvasScript : MonoBehaviour
{
    [SerializeField] GameObject book;
    [SerializeField] Transform target;
    public void MemoryBook()
    {
        if (book != null && target != null)
        {
            Instantiate(book, target.position, target.rotation);
        }
    }

}
