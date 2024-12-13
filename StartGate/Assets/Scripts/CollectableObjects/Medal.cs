
using TMPro;
using UnityEngine;

public class Medal : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    public void Collect()
    {
        m_Text.text = "Bu madalyayı hiç haketmemiştim";
    }
}
