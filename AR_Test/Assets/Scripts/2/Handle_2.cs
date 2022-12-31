using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handle_2 : MonoBehaviour
{
    bool PowerToogleButton;
    public Image[] lines;
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            foreach (Image line in lines)
                line.enabled = true;
        }
        else
        {
            PowerToogleButton = false;
            foreach (Image line in lines)
                line.enabled = false;
        }
    }
}
