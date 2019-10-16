using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 2.0f;
    [SerializeField] private float BoostFactor = 4.0f;
    [SerializeField] private float gravity = 20.0f;
    //This pragma disables the warning in this one case.
#pragma warning disable 0649
    private float ModifiedSpeed;
    private Vector3 MovementDirection = Vector3.zero;

    public float GetCurrentSpeed()
    {
        return this.ModifiedSpeed;
    }

    public Vector3 GetMovementDirection()
    {
        return this.MovementDirection;
    }

    // Update is called once per frame
    void Update()
    {
        this.ModifiedSpeed = this.Speed;
        this.MovementDirection *= ModifiedSpeed;

        if (Input.GetButton("Jump"))
        {
            // makes movement faster
            this.ModifiedSpeed *= this.BoostFactor;
        }
        if (Input.GetButton("Fire2"))
        {
            // move player forward and back
            this.MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
        else
        {
            // moves side to side and up and down
            this.MovementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        }

        this.gameObject.transform.Translate(this.MovementDirection * Time.deltaTime * this.ModifiedSpeed);

    }
}
