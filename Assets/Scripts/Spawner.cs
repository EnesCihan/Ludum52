using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField]
    private GameObject seed;
    private Vector3 spawnPosition;

    [Header("Settings")]
    [SerializeField]
    private float repeatRate = 10f;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, repeatRate);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 100f);
    }

    private void Spawn()
    {
        spawnPosition = new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100));
        Instantiate(seed, spawnPosition, Quaternion.identity);
    }
}
