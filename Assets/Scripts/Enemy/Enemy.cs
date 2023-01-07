using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 100;
    int damage = 35;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            takeDamage();
        }
    }
    void takeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Spawner.numberOfEnemy--;
            Destroy(gameObject);
        }
    }
}
