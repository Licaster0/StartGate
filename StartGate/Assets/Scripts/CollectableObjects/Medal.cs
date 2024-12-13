
using TMPro;
using UnityEngine;

public class Medal : MonoBehaviour, ICollectable
{

    public void Collect()
    {
        GameManager.Instance.text.text = "Bu madalyayı hiç haketmemiştim";
    }
}
