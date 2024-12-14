using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vileda : MonoBehaviour
{
    public ViledaParts[] parts; // Tüm parçaları bu diziye atayın
    public int collectedPartsCount = 0; // Toplanan parçaların sayısını takip eder
    public bool isAssembled = false; // Vileda'nın birleştirilip birleştirilmediğini kontrol eder

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
        isAssembled = true; // Vileda artık hazır
        Debug.Log("Vileda birleştirildi! Lekeleri temizleyebilirsiniz.");
        gameObject.SetActive(true); // Vileda sahnede görünebilir (isteğe bağlı)
    }
}
