using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Transform initialPosition;

    private void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a collider tagged as "Obstacle"
        if (collision.gameObject.CompareTag("ObstacleOther"))
        {
            // Reset the car's position to the initial position
            transform.position = initialPosition.position;
        }
    }
}

