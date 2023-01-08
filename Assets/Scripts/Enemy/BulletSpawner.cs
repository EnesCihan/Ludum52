using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        InvokeRepeating("SpawnBullet", 1f, 2f);
    }
    private void Update()
    {
        if (playerController.isDead)
        {
            CancelInvoke();
        }
    }
    void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
