using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 0.5f;
    private Vector3 mouseReference = Vector3.zero;
    private Vector3 mouseOffset = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private bool isRotating;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // offset
            mouseOffset = (Input.mousePosition - mouseReference);

            if (Vector3.Dot(transform.up, Vector3.up) > 0)
            {
                transform.Rotate(transform.up, -Vector3.Dot(mouseOffset, Camera.main.transform.right) * mouseSensitivity, Space.World);
            }
            else
            {
                transform.Rotate(transform.up, Vector3.Dot(mouseOffset, Camera.main.transform.right) * mouseSensitivity, Space.World);
            }

            transform.Rotate(Camera.main.transform.right,Vector3.Dot(mouseOffset, Camera.main.transform.up) * mouseSensitivity, Space.World);

        }

        mouseReference = Input.mousePosition;

    }

}
