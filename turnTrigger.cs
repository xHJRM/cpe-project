using UnityEngine;

public class turnTrigger : MonoBehaviour
{
    public float turnForce = -90f;  // Adjust the force to control the turning strength

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the trigger on the road
        if (other.CompareTag("CurveTrigger"))
        {
            Debug.Log("turn called");
            // Apply turning force when entering the curve trigger
            TurnOnCurve();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("turn exit");
        // Reset the turning force when leaving the trigger
        if (other.CompareTag("CurveTrigger"))
        {
            ResetTurn();
        }
    }

    void TurnOnCurve()
    {
        // Apply a turning force to simulate the curve
        // You may need to adjust the force and direction based on your setup
        GetComponent<Rigidbody>().AddTorque(transform.up * turnForce, ForceMode.Impulse);
    }

    void ResetTurn()
    {
        // Reset any turning force when leaving the trigger
        // You may need additional logic based on your requirements
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
