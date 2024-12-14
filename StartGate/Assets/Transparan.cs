using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Transparan : MonoBehaviour
{
   
    public TextMeshProUGUI textToBlink; // Yanıp sönecek TextMeshPro bileşeni
    public float blinkSpeed = 1f; // Yanıp sönme hızı

    private bool fadingOut = true; // Şu anda azalma mı oluyor?

    private void Update()
    {
        if (textToBlink != null)
        {
            Color currentColor = textToBlink.color;

            // Alfa kanalını artır veya azalt
            if (fadingOut)
            {
                currentColor.a -= Time.deltaTime * blinkSpeed;
                if (currentColor.a <= 0f)
                {
                    currentColor.a = 0f;
                    fadingOut = false; // Yön değiştir
                }
            }
            else
            {
                currentColor.a += Time.deltaTime * blinkSpeed;
                if (currentColor.a >= 1f)
                {
                    currentColor.a = 1f;
                    fadingOut = true; // Yön değiştir
                }
            }

            // Rengi güncelle
            textToBlink.color = currentColor;
        }
    }
}
