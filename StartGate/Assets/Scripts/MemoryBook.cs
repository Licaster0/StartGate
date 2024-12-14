using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MemoryBook : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    public float pullSpeed = 2f;
    public float shrinkSpeed = 0.5f;

    private Transform player;

    public void Initialize(Transform playerTransform)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransform = player;
        StartCoroutine(MoveAndPullPlayer());
    }

    IEnumerator MoveAndPullPlayer()
    {
        Vector3 targetPosition = player.position + (Vector3.up * moveDistance);
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(player.position, transform.position) > 0.1f)
        {
            player.position = Vector3.Lerp(player.position, transform.position, pullSpeed * Time.deltaTime);

            player.localScale = Vector3.Lerp(player.localScale, Vector3.zero, shrinkSpeed * Time.deltaTime);

            yield return null;
        }


        yield return new WaitForSeconds(0.5f);
        Debug.Log("Sonraki Sahne");
    }
}
