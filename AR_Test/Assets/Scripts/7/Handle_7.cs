using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handle_7 : MonoBehaviour
{
    bool PowerToogleButton;
    public GameObject reverseButton;
    public Image[] lines;
    public Transform[] clips;
    public FollowPath[] pts;
    public Transform direction;
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            reverseButton.SetActive(false);
            direction.gameObject.SetActive(true);
            foreach (Image line in lines)
                line.enabled = true;
        }
        else
        {
            PowerToogleButton = false;
            reverseButton.SetActive(true);
            direction.gameObject.SetActive(false);
            foreach (Image line in lines)
                line.enabled = false;
        }
    }
    public void Reverse()
    {
        Vector3 temp = clips[0].position;
        clips[0].position = clips[1].position;
        clips[1].position = temp;

        direction.Rotate(new Vector3(0f, 180f, 0f));
        for (int i = 0; i < direction.childCount; i++)
            direction.GetChild(i).transform.Rotate(new Vector3(0f, 180f, 0f));
        foreach (FollowPath pt in pts)
            foreach (Transform rt in pt.routes)
                for (int i = 0; i < rt.childCount; i++)
                    rt.GetChild(0).SetSiblingIndex(rt.childCount - 1 - i);
    }
}
