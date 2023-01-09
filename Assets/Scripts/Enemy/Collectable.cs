using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    PlayerController playerController;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.currentHealth += Random.Range(10, 16);
            GameManager.SeedCount++;
            Destroy(gameObject);
        }
    }
}
