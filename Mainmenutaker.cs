using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcherr : MonoBehaviour
{
    void Update()
    {
        // Check for Oculus Touch input
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            // Load the MainMenu scene
            SceneManager.LoadScene("Main Menu");
        }
    }
}