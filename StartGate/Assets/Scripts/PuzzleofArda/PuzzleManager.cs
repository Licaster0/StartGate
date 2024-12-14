﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public TextMeshProUGUI textToBlink; // Yanıp sönecek TextMeshPro bileşeni
    public GameObject textttoblink2;
    public float blinkSpeed = 1f; // Yanıp sönme hızı

    private bool fadingOut = true; // Şu anda azalma mı oluyor?
    
    public GameObject harfler;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public Transform p1pos;
    public Transform p2pos;
    public Transform p3pos;
    public Transform p4pos;
    public Transform p5pos;

    private void Update()
    {
        if (p1.transform.position == p1pos.position && p2.transform.position == p2pos.position && p3.transform.position == p3pos.position && p4.transform.position == p4pos.position && p5.transform.position == p5pos.position)
        {
            Debug.Log("Puzzle tamamlandı");
            Invoke("canvasac", 2);
            Invoke("yazıgozuk", 4);
            
            
        }
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
    public void canvasac()
    {
        harfler.SetActive(true);
    }
    public void yazıgozuk()
    {
        textttoblink2.SetActive(true);
    }





}
