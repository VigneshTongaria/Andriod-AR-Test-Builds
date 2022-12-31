using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public Animator anim;
    public SoundA1 src;
    public bool[] y = new bool[4] { true, true, true, true };
    public void PlaceStirrer()
    {
        anim.SetBool("PlaceStirrer", true);
    }
    public void PlayPour(int x)
    {
        if (y[x])
        {
            src.PlayClip(x, true, false);
            y[x] = !y[x];
        }
    }
}
