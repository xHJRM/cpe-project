using System.Collections;
using UnityEngine;

public class StoplightChangeLightsAfterDelay : MonoBehaviour
{
    // Reference to the red light GameObject
    public GameObject Stoplight1_Red;

    // Reference to the green light GameObject
    public GameObject Stoplight1_Green;

    // Reference to the target empty object
    public GameObject targetEmptyObject;

    // Boolean flag to track if the lights are in the process of changing
    private bool lightsChanging = false;

    private void Start()
    {
        Stoplight1_Red.SetActive(true);
        Stoplight1_Green.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the one you are interested in.
        if (other.CompareTag("Player") && !lightsChanging)
        {
            // Set the flag to prevent multiple changes while the lights are already changing
            lightsChanging = true;

            // Start the coroutine to wait for 3 seconds before changing the lights
            StartCoroutine(ChangeLightsAfterDelay());
        }
    }

    // Coroutine to wait for a specified delay before changing the lights
    private IEnumerator ChangeLightsAfterDelay()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Toggle the visibility of the red and green lights.
        // If the red light is active, set it to inactive, and vice versa.
        Stoplight1_Red.SetActive(!Stoplight1_Red.activeSelf);
        Stoplight1_Green.SetActive(!Stoplight1_Green.activeSelf);

            // Check if the green light is active before disabling the trigger
            if (Stoplight1_Green.activeSelf)
            {
                // Disable the box collider of the target empty object
                if (targetEmptyObject != null)
                {
                    BoxCollider emptyObjectCollider = targetEmptyObject.GetComponent<BoxCollider>();
                    if (emptyObjectCollider != null)
                    {
                        emptyObjectCollider.enabled = false;
                    }
                }
            }

        // Reset the flag after the lights have changed
        lightsChanging = false;
    }
}
