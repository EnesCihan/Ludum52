using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static public int numberOfEnemy = 0;
    PlayerController playerController;
    [Header("Refrence")]
    [SerializeField] private GameObject seed;
    private Vector3 spawnPosition;

    [Header("Settings")]
    [SerializeField] float spawnRate;


    void Start()
    {
        StartCoroutine(SpawnSeed());
    }
    void Update()
    {
        if (numberOfEnemy >= 5)
        {
            Die();
        }
    }
    IEnumerator SpawnSeed()
    {
        while (numberOfEnemy < 5)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Spawn()
    {
        spawnPosition = new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100));
        Instantiate(seed, spawnPosition, Quaternion.identity);
        numberOfEnemy++;
    }
    void Die()
    {
        Debug.Log("You Lost!");
        PlayerController.isDead = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 100f);
    }
}
