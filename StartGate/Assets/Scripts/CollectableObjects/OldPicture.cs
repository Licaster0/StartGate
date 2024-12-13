
using TMPro;
using UnityEngine;

public class OldPicture : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    public void Collect()
    {
        m_Text.text = "Sevgilim seni ihmal etmemeliydim...";
    }
}
