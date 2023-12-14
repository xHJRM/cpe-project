using UnityEngine;
using UnityEngine.SceneManagement;

public class CPUCarController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("co"))
        {
            Debug.Log("CPUCar collided with 'co'. Resetting scene.");
            // Reset the "Overtaking" scene if collided with "co"
            ResetScene();
        }
    }

    void ResetScene()
    {
        // Reset the "Overtaking" scene
        SceneManager.LoadScene("Overtaking");
    }
}
