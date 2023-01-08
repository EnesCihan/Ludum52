using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] GameObject collectableSeed;
    int health = 100;
    int damage = 51;


    void OnTriggerEnter(Collider other)
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
            Instantiate(collectableSeed, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
