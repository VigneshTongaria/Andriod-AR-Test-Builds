using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Rotate[] rots;
    public void StartRotationNow()
    {
        foreach (Rotate rot in rots)
        {
            rot.flag = true;
        }
    }
}
