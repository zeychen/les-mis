using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : AbstractCameraController
{
    [SerializeField] private Camera ManagedCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    //This pragma disables the warning in this one case.
#pragma warning disable 0649

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Awake()
    {
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        var targetPosition = this.Target.transform.position;
        var cameraPosition = this.ManagedCamera.transform.position;

        cameraPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);

        this.ManagedCamera.transform.position = cameraPosition;

        ////rotates camera according to mouse input
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}


