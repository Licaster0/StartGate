
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brush : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    public void Collect()
    {
        m_Text.text = "Annecim burda seninde dis fircan olurdu";
        StartCoroutine(enumerator());
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(3);

    }
}
