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


    private void Update()
    {
        RotatePlayer();
        MakePlayerMove();
    }

    void MakePlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

    }
    private void RotatePlayer()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed;
        transform.Rotate(Vector3.up * mouseX);

    }
}
