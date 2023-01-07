using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float verticalInput;
    float horizontalInput;
    [SerializeField] private float playerSpeed;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        MakePlayerMove();
    }
    void MakePlayerMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
    }
}
