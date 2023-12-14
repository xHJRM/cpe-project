using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 50f;
    private Rigidbody rb;

    // Variable to track whether the car is turning
    private bool isTurning = false;

    // Target Y rotation for the turn
    private float targetYRotation = -180f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;

        // Check if the car is turning and smoothly rotate if needed
        if (isTurning)
        {
            SmoothRotate();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object's name is "junction"
        if (other.gameObject.name == "junction")
        {
            StartTurn();
        }
    }

    void StartTurn()
    {
        // Set the flag to start turning
        isTurning = true;
    }

    void SmoothRotate()
    {
        // Calculate the target rotation to smoothly turn the car left
        Quaternion targetRotation = Quaternion.Euler(0, targetYRotation, 0);

        // Use Quaternion.RotateTowards to smoothly rotate the car
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Check if the target rotation is reached
        if (transform.eulerAngles.y <= targetYRotation)
        {
            // Stop turning when the target Y rotation is reached
            isTurning = false;
        }
    }
}
