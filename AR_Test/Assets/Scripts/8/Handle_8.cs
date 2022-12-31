using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Handle_8 : MonoBehaviour
{
    bool PowerToogleButton;
    public GameObject reverseButton;
    public Transform[] clips;
    public Vector3[] rots;
    public Transform[] trans;
    public Vector3[] initialRots;
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            reverseButton.SetActive(false);
            for (int i = 0; i < 3; i++)
                trans[i].localRotationTransition(Quaternion.Euler(rots[i]), 0.5f, LeanEase.Decelerate);
        }
        else
        {
            PowerToogleButton = false;
            reverseButton.SetActive(true);
            for (int i = 0; i < 3; i++)
                trans[i].localRotationTransition(Quaternion.Euler(initialRots[i]), 0.5f, LeanEase.Decelerate);
        }
    }
    public void Reverse()
    {
        Vector3 temp = clips[0].position;
        clips[0].position = clips[1].position;
        clips[1].position = temp;
        rots[0] += rots[0].x > initialRots[0].x ? new Vector3(-4f, 0f, 0f) : new Vector3(4f, 0f, 0f);
        rots[1] += rots[1].x > initialRots[1].x ? new Vector3(-4f, 0f, 0f) : new Vector3(4f, 0f, 0f);
        rots[2] += rots[2].z > initialRots[2].z ? new Vector3(0f, 0f, -4f) : new Vector3(0f, 0f, 4f);
    }
}
