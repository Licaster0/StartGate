using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Buffers;

public class Scene4CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject bookPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private Sprite switchOnSprite;
    [SerializeField] private Sprite switchOffSprite;

    private GameObject spawnedBook;
    private Image spriteImage;

    private void Start()
    {
        // Bu objedeki SpriteRenderer bileşenini al
        spriteImage = GameObject.Find("Test").GetComponent<Image>();

        // Başlangıçta switch kapalı görünümüyle başla
        if (spriteImage != null && switchOffSprite != null)
        {
            spriteImage.sprite = switchOffSprite;
        }
    }

    public void MemoryBook()
    {
        if (spawnedBook == null)
        {
            // Kitap objesi oluşturuluyor
            spawnedBook = Instantiate(bookPrefab, target.position, target.rotation);
            spawnedBook.GetComponent<MemoryBook>().Initialize(transform);

            // Sprite'i "açık" hale getir
            if (spriteImage != null && switchOnSprite != null)
            {
                spriteImage.sprite = switchOnSprite;
            }
        }
        else
        {
            // Kitap objesi siliniyor
            Destroy(spawnedBook);
            spawnedBook = null;

            // Sprite'i "kapalı" hale getir
            if (spriteImage != null && switchOffSprite != null)
            {
                spriteImage.sprite = switchOffSprite;
            }
        }
    }
}
