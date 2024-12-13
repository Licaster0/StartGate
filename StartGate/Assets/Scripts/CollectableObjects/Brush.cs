
using TMPro;
using UnityEngine;

public class Brush : MonoBehaviour, ICollectable
{

    public void Collect()
    {
        GameManager.Instance.text.text = "Annecim burda seninde diş fırçan olurdu";
    }

}
