using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeScreenshot : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ScreenCapture.CaptureScreenshot("Screenshots/" + SceneManager.GetActiveScene().name + "/GameScreenshot" + PlayerPrefs.GetInt("ssNumber") + ".png");
            PlayerPrefs.SetInt("ssNumber", PlayerPrefs.GetInt("ssNumber") + 1);
        }
    }
}
