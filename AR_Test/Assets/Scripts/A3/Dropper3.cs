using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper3 : MonoBehaviour
{
    public AHandle_3 ah;
    public Animator anim;
    public void PlaceStirrer()
    {
        anim.SetBool("PlaceStirrer", true);
    }
    public void ChangeColor()
    {
        ah.AddIndicator();
    }
}