using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : AbstractCameraController
{
    [SerializeField] private Camera ManagedCamera;
    //This pragma disables the warning in this one case.
#pragma warning disable 0649


    void Awake()
    {
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        var targetPosition = this.Target.transform.position;

        var cameraPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);

        this.ManagedCamera.transform.position = cameraPosition;

    }
}


