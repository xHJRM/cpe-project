using UnityEngine;

public class IndicatorLightsController : MonoBehaviour
{
    public bool leftIndicatorEnabled = false; // If the left indicator is on
    public bool rightIndicatorEnabled = false; // If the right indicator is on
    public float indicatorDelayBetweenFlashes = 0.5f; // Delay between indicator flashes
    public Light leftIndicatorLight; // Set this to your light
    public Light rightIndicatorLight; // Set this to your light

    void Update()
    {
        // Left indicator
        if (OVRInput.GetDown(OVRInput.Button.One)) // A button on the left controller
        {
            if (!leftIndicatorEnabled)
            {
                rightIndicatorEnabled = false; // Turn off the right indicator
                leftIndicatorEnabled = true; // Turn the left indicator on
                InvokeRepeating("LeftIndicatorFlasher", 0f, indicatorDelayBetweenFlashes); // Flash the indicator
            }
            else
            {
                leftIndicatorEnabled = false; // Turn off the left indicator
                leftIndicatorLight.enabled = false; // Ensure the light is off
                CancelInvoke("LeftIndicatorFlasher"); // Stop the flashing
            }
        }

        // Right Indicator
        if (OVRInput.GetDown(OVRInput.Button.Two)) // B button on the right controller
        {
            if (!rightIndicatorEnabled)
            {
                leftIndicatorEnabled = false; // Turn off the left indicator
                rightIndicatorEnabled = true; // Turn the right indicator on
                InvokeRepeating("RightIndicatorFlasher", 0f, indicatorDelayBetweenFlashes); // Flash the indicator
            }
            else
            {
                rightIndicatorEnabled = false; // Turn off the right indicator
                rightIndicatorLight.enabled = false; // Ensure the light is off
                CancelInvoke("RightIndicatorFlasher"); // Stop the flashing
            }
        }
    }

    void LeftIndicatorFlasher()
    {
        leftIndicatorLight.enabled = !leftIndicatorLight.enabled; // Switch light from enabled to disabled and back again
    }

    void RightIndicatorFlasher()
    {
        rightIndicatorLight.enabled = !rightIndicatorLight.enabled; // Switch light from enabled to disabled and back again
    }
}
