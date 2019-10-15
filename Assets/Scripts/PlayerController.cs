using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 200.0f;
    [SerializeField] private float BoostFactor = 4.0f;
    [SerializeField] private float gravity = 20.0f;
    //This pragma disables the warning in this one case.
#pragma warning disable 0649
    private float ModifiedSpeed;
    private Vector3 MovementDirection = Vector3.zero;
    CharacterController characterController;

    public float GetCurrentSpeed()
    {
        return this.ModifiedSpeed;
    }

    public Vector3 GetMovementDirection()
    {
        return this.MovementDirection;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ModifiedSpeed = this.Speed;
        if (characterController.isGrounded)
        {
            MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            MovementDirection *= ModifiedSpeed;

            if (Input.GetButton("Jump"))
            {
                this.ModifiedSpeed *= this.BoostFactor;
            }
        }

        this.MovementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        this.gameObject.transform.Translate(this.MovementDirection * Time.deltaTime * this.ModifiedSpeed);
    }
}
