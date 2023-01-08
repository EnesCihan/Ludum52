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
        while (numberOfEnemy < maxEnemy && playerController.isDead)
        {
            if (spawnRate > 5)
            {
                spawnRate *= 0.95f;
            }
            else
            {
                spawnRate = 4.95f;
            }
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition;
        spawnPosition = new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100));

        Instantiate(seed, spawnPosition, Quaternion.Euler(90f, 0f, 0f));
        numberOfEnemy++;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 100f);
    }
}
