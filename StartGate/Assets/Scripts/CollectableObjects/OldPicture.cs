using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OldPicture : MonoBehaviour, ICollectable
{
    public TMP_Text m_Text;
    private bool m_IsPlaying = false;
    public void Collect()
    {
        if (!m_IsPlaying)
        {
            m_Text.text = "Sevgilim seni ihmal etmemeliydim...";

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
<<<<<<< HEAD
        
        SceneManager.LoadScene(7);
=======
        SceneManager.LoadScene(9);
>>>>>>> 8e231ec183b69ca9912a8c54754eac022e820287
    }
}
