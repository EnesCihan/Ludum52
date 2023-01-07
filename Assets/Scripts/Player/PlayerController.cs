using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float verticalInput;
    float horizontalInput;
    float mouseX;
    [Header("Settings")]
    [SerializeField] float playerSpeed;
    [SerializeField] float cameraSpeed;
    [SerializeField] float rollingDistance = 30;




    private void Update()
    {
        RotatePlayer();
        MakePlayerMove();
        RollPlayer();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + direction * rollingDistance * -1);
        }
    }
}
