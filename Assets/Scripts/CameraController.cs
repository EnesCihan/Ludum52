using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float turnSpeed = 1;
    private Vector3 offsetX;
    private Vector3 offsetY;



    void LateUpdate()
    {
        RotateTheCamera();
    }
    private void RotateTheCamera()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;
        transform.position = player.position + offsetX;
    }
}
