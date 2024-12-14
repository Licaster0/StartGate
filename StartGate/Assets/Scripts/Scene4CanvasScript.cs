using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        // Bu objedeki SpriteRenderer bileþenini al
        spriteImage = GameObject.Find("Test").GetComponent<Image>();

        // Baþlangýçta switch kapalý görünümüyle baþla
        if (spriteImage != null && switchOffSprite != null)
        {
            spriteImage.sprite = switchOffSprite;
        }
    }

    public void MemoryBook()
    {
        if (spawnedBook == null)
        {
            // Kitap objesi oluþturuluyor
            spawnedBook = Instantiate(bookPrefab, target.position, target.rotation);

            // Sprite'i "açýk" hale getir
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

            // Sprite'i "kapalý" hale getir
            if (spriteImage != null && switchOffSprite != null)
            {
                spriteImage.sprite = switchOffSprite;
            }
        }
    }
}
