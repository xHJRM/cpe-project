using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Overtaking");
    }

    public void LightBtn()
    {
        SceneManager.LoadScene("StopLight");
    }

    public void JunctionBtn()
    {
        SceneManager.LoadScene("TJunction");
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
