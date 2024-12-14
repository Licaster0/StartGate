using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textdrag : MonoBehaviour
{
    private RectTransform rectTransform; // UI elemanının transformu
    private Canvas canvas; // UI elemanının bağlı olduğu canvas
    private CanvasGroup canvasGroup; // Sürükleme sırasında tıklanabilirliği kontrol etmek için

    private Vector2 offset; // Fare ile UI elemanı arasındaki mesafe

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>(); // Canvas referansını bul
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>(); // Eğer yoksa ekle
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Fare tıklandığında sürükleme başlasın
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
        canvasGroup.blocksRaycasts = false; // Diğer UI elemanlarıyla çakışmayı önlemek için kapat
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Sürükleme sırasında UI elemanını fareye taşı
        Vector2 mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out mousePosition);
        rectTransform.anchoredPosition = mousePosition - offset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Fare bırakıldığında sürükleme bitsin
        canvasGroup.blocksRaycasts = true; // Diğer UI elemanlarıyla etkileşim geri gelir
    }
}
