using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Anne : MonoBehaviour
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
        dialogueText.text = "Anne...";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "Sensin..";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "Seni çok ozledim";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "Beni affet";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "- Kızım";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "- Sakin ol.. Kabus görmüs olmalısın";
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "- Ben burdayım";

    }
}
