using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    Rigidbody bulletRigidBody;
    PlayerController playerController;
    Vector3 moveDirection;

    void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        SpawnBullet();
    }
    void SpawnBullet()
    {
        moveDirection = (playerController.transform.position + new Vector3(0f, 1.1f, 0f) - transform.position).normalized * bulletSpeed;
        bulletRigidBody.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        float bulletDamage = Random.Range(10, 16);
        if (other.CompareTag("Player"))
        {
            playerController.currentHealth -= bulletDamage;
            Destroy(gameObject);
        }
        else if (other.CompareTag("tree"))
        {
            Destroy(gameObject);
        }
    }

}
