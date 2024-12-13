
using TMPro;
using UnityEngine;

public class Brush : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    public void Collect()
    {
        m_Text.text = "Annecim burda seninde diş fırçan olurdu";
    }

}
