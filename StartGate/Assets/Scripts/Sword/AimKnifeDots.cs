using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimKnifeDots : MonoBehaviour
{

    [SerializeField] GameObject swordPrefab;
    [SerializeField] private int pierceAmount;
    [SerializeField] private float pierceGravity;

    [Header("Sword Launch")]
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;
    private Vector2 finalDir;

    [Header("Aim dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBeetwenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;

    [SerializeField] private GameObject[] dots;
    private PlayerMovement player;

    private void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
        GenereateDots();
        swordGravity = pierceGravity;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            finalDir = new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y);
            LaunchSword();
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            DotsActive(true);
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.position = DotsPosition(i * spaceBeetwenDots);
            }
        }

    }

    public void LaunchSword()
    {
        GameObject sword = Instantiate(swordPrefab, player.transform.position, Quaternion.identity);
        Knife_Controller swordController = sword.GetComponent<Knife_Controller>();

        swordController.SetupPierce(pierceAmount);

        swordController.SetupSword(finalDir, swordGravity, player);

        DotsActive(false);

    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;

        return direction;
    }

    public void DotsActive(bool _isActive)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(_isActive);
        }
    }

    private void GenereateDots()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity, dotsParent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPosition(float t)
    {
        Vector2 position = (Vector2)player.transform.position + new Vector2(
            AimDirection().normalized.x * launchForce.x,
            AimDirection().normalized.y * launchForce.y) * t + .5f * (Physics2D.gravity * swordGravity) * (t * t);

        return position;
    }

}
