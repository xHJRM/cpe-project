using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRCarControllerr : MonoBehaviour
{
    public GameObject LeftHandMidpoint;
    public GameObject RightHandMidpoint;
    public GameObject SteeringWheel;
    public GameObject Car;

    public float dampingFactor = 0.1f; // Adjustable damping factor
    public float moveSpeed = 5f; // Speed at which the car moves

    // Reference to the TeleportTrigger collider
    public Collider teleportTriggerCollider;

    private bool isGreenLight = false; // Flag to track if the light is green

    void Update()
    {
        Vector3 leftHandPos = LeftHandMidpoint.transform.position;
        Vector3 rightHandPos = RightHandMidpoint.transform.position;

        // Calculate the midpoint between the hands and find the perpendicular bisector
        Vector3 handMidpoint = (leftHandPos + rightHandPos) / 2;
        Vector3 line = rightHandPos - leftHandPos;
        Vector3 perpBisector = Vector3.Cross(line, Vector3.forward).normalized;

        // Calculate the angle between the y-axis and the perpendicular bisector
        float angle = Vector3.SignedAngle(Vector3.up, perpBisector, Vector3.forward);

        // Invert the angle if necessary and apply damping
        angle = -angle * dampingFactor;

        // Rotate the steering wheel
        SteeringWheel.transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Optional: Visualize the lines
        Debug.DrawLine(leftHandPos, rightHandPos, Color.red); // Line between hands
        Debug.DrawLine(handMidpoint, handMidpoint + perpBisector * 0.5f, Color.blue); // Perpendicular bisector

        // Rotate the car based on the steering wheel
        Quaternion carRotation = Quaternion.Euler(0, Car.transform.eulerAngles.y + angle * Time.deltaTime, 0);
        Car.transform.rotation = carRotation;

        // Keyboard input for moving forward and backward
        float keyboardInput = Input.GetAxis("Vertical");

        // Move car forward with 'W' key
        if (keyboardInput > 0)
        {
            Car.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        // Move car backward with 'S' key
        else if (keyboardInput < 0)
        {
            Car.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeleportTrigger"))
        {
            if (!isGreenLight)
            {
                ReloadScene();
            }
            else
            {
                DisableTeleportTriggerCollider();
            }
        }
        else if (other.CompareTag("end"))
        {
            LoadMainMenuScene();
        }
    }

    void ReloadScene()
    {
        // Reload the scene with the name "StopLight"
        SceneManager.LoadScene("StopLight");
    }

    void LoadMainMenuScene()
    {
        // Load the "MainMenu" scene
        SceneManager.LoadScene("MainMenu");
    }

    void DisableTeleportTriggerCollider()
    {
        // Find all game objects with the tag "TeleportTrigger" in the scene
        GameObject[] teleportTriggers = GameObject.FindGameObjectsWithTag("TeleportTrigger");

        // Disable (deactivate) all found game objects
        foreach (GameObject teleportTrigger in teleportTriggers)
        {
            teleportTrigger.SetActive(false);
        }
    }



    // Call this method when the lights change to green
    public void SetGreenLight(bool isGreen)
    {
        isGreenLight = isGreen;
    }
}