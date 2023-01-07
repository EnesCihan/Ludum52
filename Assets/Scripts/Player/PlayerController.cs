using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidBody;
    float verticalInput;
    float horizontalInput;
    float mouseX;
    [Header("Settings")]
    [SerializeField] float playerSpeed;
    [SerializeField] float cameraSpeed;
    [SerializeField] float rollingDistance;
    [SerializeField] float dodgeCooldown = 2;
    float actCooldown;




    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotatePlayer();
        RollPlayer();
        MakePlayerMove();
    }

    void MakePlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

    }
    void RotatePlayer()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed;
        transform.Rotate(Vector3.up * mouseX);
    }
    void RollPlayer()
    {
        Vector3 direction = transform.position - transform.GetChild(0).position;
        if (actCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                actCooldown = dodgeCooldown;
                GetComponent<Rigidbody>().MovePosition(transform.position + direction * rollingDistance * -1);
            }
        }
        else
        {
            actCooldown -= Time.deltaTime;
        }
    }

}
