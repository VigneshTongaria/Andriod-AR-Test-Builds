using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public AHandle_1 ah;
    public GameObject nextButton;
    public void ChangeColor(int x)
    {
        if (x == 0) ah.ChangeToBlue();
        else ah.ChangeToRed();
    }
    public void ShowNext()
    {
        nextButton.SetActive(true);
    }
}
