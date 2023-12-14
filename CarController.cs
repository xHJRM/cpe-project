using UnityEngine;

public class CarController1 : MonoBehaviour
{
    public float speed = 30f; // Speed of the car in km/h

    private void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        // Convert speed from km/h to m/s
        float speedInMetersPerSecond = speed / 3.6f;

        // Move the car forward
        transform.Translate(Vector3.forward * speedInMetersPerSecond * Time.deltaTime);
    }
}

