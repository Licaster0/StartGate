using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medal : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    public void Collect()
    {
        m_Text.text = "Bu madalyayi hic haketmemistim";
        StartCoroutine(enumerator());
    }
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(5);
    }
}
