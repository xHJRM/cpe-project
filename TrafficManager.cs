using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public GameObject carPrefab;
    public int numberOfCars = 10;

    private void Start()
    {
        SpawnCars();
    }

    private void SpawnCars()
    {
        for (int i = 0; i < numberOfCars; i++)
        {
            // Instantiate a new car at the spawn point
            GameObject newCar = Instantiate(carPrefab, transform.position, Quaternion.identity);

            // Attach the CarController script to the instantiated car
            CarController carController = newCar.GetComponent<CarController>();

            // Set any additional properties if needed

            // Parent the car to the TrafficManager for organization (optional)
            newCar.transform.parent = transform;
        }
    }
}
