using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OldPicture : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    int x = 0;
    public void Collect()
    {
        if (x != 0)
            return;

        m_Text.text = "Sevgilim seni ihmal etmemeliydim...";
        StartCoroutine(enumerator());
        x++;
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(9);
    }
}
