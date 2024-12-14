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
        // Bu objedeki SpriteRenderer bile�enini al
        spriteImage = GameObject.Find("Test").GetComponent<Image>();

        // Ba�lang��ta switch kapal� g�r�n�m�yle ba�la
        if (spriteImage != null && switchOffSprite != null)
        {
            spriteImage.sprite = switchOffSprite;
        }
    }

    public void MemoryBook()
    {
        if (spawnedBook == null)
        {
            // Kitap objesi olu�turuluyor
            spawnedBook = Instantiate(bookPrefab, target.position, target.rotation);

            // Sprite'i "a��k" hale getir
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

            // Sprite'i "kapal�" hale getir
            if (spriteImage != null && switchOffSprite != null)
            {
                spriteImage.sprite = switchOffSprite;
            }
        }
    }
}
