using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] GameObject enemyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Instantiate(enemyPrefab, transform.position + new Vector3(0f, 3f, 0f), Quaternion.Euler(90f, 0f, 0f));
            Destroy(gameObject);
        }
    }


}
