using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lekeler : MonoBehaviour
{
    public Leke[] parts; // Tüm parçaları bu diziye atayın
    public int collectedPartsCount = 0; // Toplanan parçaların sayısını takip eder

    public void OnPartCollected()
    {
        collectedPartsCount++; // Toplanan parçaların sayısını artır

        // Eğer tüm parçalar toplandıysa birleştirme işlemini başlat
        if (collectedPartsCount >= parts.Length)
        {
            AssembleVileda();
        }
    }

    private void AssembleVileda()
    {
        // Birleştirme işlemi burada yapılabilir
        gameObject.SetActive(true); // Örneğin, Vileda'yı sahnede göster
    }
}
