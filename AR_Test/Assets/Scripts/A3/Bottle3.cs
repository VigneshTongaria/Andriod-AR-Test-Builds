using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle3 : MonoBehaviour
{
    public SoundA1 src;
    public bool[] y = new bool[4] { true, true, true, true };
    public GameObject IButton;
    public void PlayPour(int x)
    {
        if (y[x])
        {
            src.PlayClip(x, true, false);
            y[x] = !y[x];
        }
    }
    public void ShowObj()
    {
        IButton.SetActive(true);
    }
}
