
using UnityEngine;

public class OldPicture : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        GameManager.Instance.text.text = "Sevgilim seni ihmal etmemeliydim...";
    }
}
