using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Target coordinates to teleport the player to
    private Vector3 targetCoordinates = new Vector3(-0.938f, 0.455f, -161.1f);

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the trigger collider
        if (other.CompareTag("TeleportTrigger"))
        {
            // Teleport the player to the target coordinates
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        // Set the player's position to the target coordinates
        transform.position = targetCoordinates;

        // Optionally, you can reset the player's velocity to zero
        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
    }
}




