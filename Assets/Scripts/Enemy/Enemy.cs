using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] GameObject collectableSeed;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            takeDamage();
        }
    }
    void takeDamage()
    {
        int health = 100;
        int damage = Random.Range(35, 67);
        health -= damage;
        if (health <= 0)
        {
            Spawner.numberOfEnemy--;
            Instantiate(collectableSeed, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
