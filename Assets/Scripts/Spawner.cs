using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    static public int numberOfEnemy = 0;
    [Header("Refrence")]
    [SerializeField] private GameObject seed;
    private Vector3 spawnPosition;

    [Header("Settings")]
    [SerializeField] float spawnRate;
    [SerializeField] int maxEnemy;


    void Start()
    {
        StartCoroutine(SpawnSeed());
    }
    void Update()
    {
        if (numberOfEnemy >= maxEnemy && !PlayerController.isDead)
        {
            Die();
        }
    }
    IEnumerator SpawnSeed()
    {
        while (numberOfEnemy < maxEnemy && !PlayerController.isDead)
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
        spawnPosition = new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100));
        Instantiate(seed, spawnPosition, Quaternion.Euler(90f, 0f, 0f));
        numberOfEnemy++;
    }
    void Die()
    {
        PlayerController.isDead = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 100f);
    }
}
