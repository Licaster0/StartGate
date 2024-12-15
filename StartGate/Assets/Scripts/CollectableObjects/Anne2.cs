using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Anne2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    bool isInteracted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteracted)
        {
            Collect();
            isInteracted = false;
        }
    }

    private void Collect()
    {
        StartCoroutine(DialogueControl());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueText.text = "Anneyle konusmak icin E'ye bas";
            isInteracted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracted = false;
            dialogueText.text = "";
        }
    }

    IEnumerator DialogueControl()
    {
        dialogueText.text = "Annecim";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Nasılsın";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Yapmami istedigin birsey varmiiii:)";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "- Hayır kızım";
        yield return new WaitForSeconds(1.7f);
        dialogueText.text = "- Hep boyle durust ol. Hep boyle guzel ol";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "- Bir ihtiyicim yok";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "Tamamdiir annemm (sarilir)";

    }
}
