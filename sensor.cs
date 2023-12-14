using UnityEngine;

public class RoadController : MonoBehaviour
{
    public Transform userCar;     // Reference to the user car's transform
    public Transform cpuCar;      // Reference to the CPU car's transform
    public Transform sensor;      // Reference to the sensor's transform

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has a tag "Car"
        if (other.CompareTag("Car"))
        {
            // Check if the triggering object is the CPU car
            if (other.transform == cpuCar)
            {
                // Check if the CPU car is in front of the user car
                if (cpuCar.position.z > userCar.position.z)
                {
                    // Stop the simulation
                    Time.timeScale = 0f;

                    // Print a failure message to the console
                    Debug.Log("Sorry, you need to be in front of the CPU car to pass. Restart the game.");

                    // You can also display a UI message or perform other actions as needed for failure
                }
            }
            else if (other.CompareTag("FinishLine"))
            {
                // Stop the simulation
                Time.timeScale = 0f;

                // Print a message to the console congratulating the user
                Debug.Log("Congratulations! You have passed.");

                // You can also display a UI message or perform other actions as needed for success
            }
        }
    }
}
