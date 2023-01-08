using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public int numberOfEnemy = 0;
    public int maxEnemy = 20;
    PlayerController playerController;

    [Header("Refrence")]
    [SerializeField] private GameObject seed;

    [Header("Settings")]
    [SerializeField] float spawnRate;
    [SerializeField] float minSpawnRate;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        StartCoroutine(SpawnSeed());
    }

    void Update()
    {
        if (numberOfEnemy >= maxEnemy && playerController.isDead)
        {
            playerController.Die();
        }
    }
    IEnumerator SpawnSeed()
    {
        while (numberOfEnemy < maxEnemy && !playerController.isDead)
        {
            if (spawnRate > minSpawnRate)
            {
                spawnRate *= 0.95f;
            }
            else
            {
                spawnRate = minSpawnRate;
            }
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition;
        spawnPosition = transform.position + new Vector3(Random.Range(-90, 90), 0, Random.Range(-90, 90));

        Instantiate(seed, spawnPosition, Quaternion.Euler(90f, 0f, 0f));
        numberOfEnemy++;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 90f);
    }
}
