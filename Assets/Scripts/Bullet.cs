using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 4f;
    Rigidbody rb;
    GameObject player;
    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 4f);

    }
    
    void Update()
    {

    }
   
}
