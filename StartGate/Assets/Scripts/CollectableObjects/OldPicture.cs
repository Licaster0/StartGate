using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OldPicture : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    public void Collect()
    {
        m_Text.text = "Sevgilim seni ihmal etmemeliydim...";
        StartCoroutine(enumerator());
    }
   private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(6);
    }
}
