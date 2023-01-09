using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] GameObject collectableSeed;
    [SerializeField] AudioSource enemyAudioSource;
    [Header("Sounds")]
    [SerializeField] AudioClip takeDamageSound;
    [SerializeField] AudioClip DeathSound;
    [Header("Settings")]
    [SerializeField] float waitToDie;
    float health = 100;
    Spawner spawner;
    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            StartCoroutine(takeDamage());
            GetComponent<Animator>().SetTrigger("Hit");
        }
    }
    IEnumerator takeDamage()
    {
        float damage = Random.Range(35, 67);
        health -= damage;
        enemyAudioSource.PlayOneShot(takeDamageSound, 0.5f);
        if (health <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            spawner.numberOfEnemy--;
            Instantiate(collectableSeed, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            enemyAudioSource.PlayOneShot(DeathSound, 0.5f);
            yield return new WaitForSeconds(waitToDie);
            Destroy(gameObject);
        }
    }

}
