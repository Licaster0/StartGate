
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brush : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    int x = 0;
    public void Collect()
    {
        if (x != 0)
            return;

        m_Text.text = "Annecim burda seninde dis fircan olurdu";
        StartCoroutine(enumerator());
        x++;
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(3);
    }
}
