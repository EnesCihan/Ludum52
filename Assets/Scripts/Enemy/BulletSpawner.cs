using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    PlayerController playerController;
    Enemy enemy;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        enemy = GetComponent<Enemy>();
    }
    void Start()
    {
        InvokeRepeating("SpawnBullet", 1f, 2f);
    }
    private void Update()
    {
        if (playerController.isDead || enemy.enemyİsDead)
        {
            CancelInvoke();
        }
    }
    void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
