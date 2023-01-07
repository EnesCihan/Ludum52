using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float turnSpeed = 1;
    public float height = 3f;
    public float distance = -3f;
    private Vector3 offsetX;
    private Vector3 offsetY;
    

    void Start()
    {
        offsetX = new Vector3(0, height, distance);
        offsetY = new Vector3(0, 0, distance);
    }

    void LateUpdate()
    {
        RotateTheCamera();
    }
    private void RotateTheCamera()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;
        transform.position = player.position + offsetX;
        transform.LookAt(player.position);
    }
}
