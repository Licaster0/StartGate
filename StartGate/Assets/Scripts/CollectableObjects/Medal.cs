using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medal : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    private bool m_IsPlaying = false;
    public void Collect()
    {
        if (!m_IsPlaying)
        {
            m_Text.text = "Bu madalyayi hic haketmemistim";
            StartCoroutine(enumerator());
            m_IsPlaying = true;
        }
        else
        {
            m_Text.text = "Hatani anlayip duzelttin";
        }

    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(6);

    }
}
