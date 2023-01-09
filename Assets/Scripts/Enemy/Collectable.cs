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
            if (playerController.currentHealth == 100)
            {
                playerController.currentHealth = 100;
            }
            else
            {
                playerController.currentHealth += Random.Range(16, 25);
            }
            GameManager.SeedCount++;
            playerController.Collect();
            Destroy(gameObject);
        }
    }
}
