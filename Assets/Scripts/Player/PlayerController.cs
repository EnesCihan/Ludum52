using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    SwordAttack swordAttack;
    Spawner spawner;
    public bool isDead;
    public float currentHealth = 100;
    float verticalInput;
    float horizontalInput;
    float mouseX;
    [Header("Settings")]
    [SerializeField] float firstSpeed;
    [SerializeField] float playerRunSpeed;
    [SerializeField] float cameraSpeed;
    [SerializeField] float rollingDistance;
    [SerializeField] float dodgeCooldown = 2;
    float playerSpeed;  
    float actCooldown;

    private void Awake()
    {
        playerSpeed = firstSpeed;
        swordAttack = FindObjectOfType<SwordAttack>();
        spawner = FindObjectOfType<Spawner>();
    }
    private void Update()
    {
        if (!isDead)
        {
            MakePlayerMove();
            Run();
            RotatePlayer();
            RollPlayer();
            swordAttack.Attack();
            Die();
        }
        print(playerSpeed);
    }

    void MakePlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

        if (verticalInput != 0 || horizontalInput != 0)
        {
            GetComponent<Animator>().SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        }
        else
        {
            GetComponent<Animator>().SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }

    }
    void RotatePlayer()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed;
        transform.Rotate(Vector3.up * mouseX);
    }
    void RollPlayer()
    {
        Vector3 direction = transform.position - transform.GetChild(2).position;
        if (actCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Animator>().SetTrigger("isRoll");  
                actCooldown = dodgeCooldown;
                GetComponent<Rigidbody>().velocity = -new Vector3(direction.x, 0, direction.z).normalized * rollingDistance;
            }
        }
        else
        {

            actCooldown -= Time.deltaTime;
        }
    }

    public void Die()
    {
        if (currentHealth <= 0 || spawner.numberOfEnemy > spawner.maxEnemy)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("isDead");
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = playerRunSpeed;
            GetComponent<Animator>().SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            playerSpeed = firstSpeed;
        }
    }

    private void RollSmallCollider()
    {
        GetComponent<BoxCollider>().size = new Vector3(1, 1, 0.5f);
        GetComponent<BoxCollider>().center = new Vector3(0, 0.5f, 0);
    }

    private void RollNormalCollider()
    {
        GetComponent<BoxCollider>().size = new Vector3(1, 2, 0.5f);
        GetComponent<BoxCollider>().center = new Vector3(0, 1f, 0);
    }
}


