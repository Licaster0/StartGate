using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4CanvasScript : MonoBehaviour
{
    [SerializeField] GameObject book;
    [SerializeField] Transform target;

    public int x = 0;
    public void CreateBook()
    {
        if (x < 1)
        {
            GameObject memoryBook = Instantiate(book, target.position, Quaternion.identity);
            memoryBook.GetComponent<MemoryBook>().Initialize(transform);
        }
        x++;
    }

}
