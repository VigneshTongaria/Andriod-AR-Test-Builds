using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireRender : MonoBehaviour
{
    LineRenderer rend;
    Transform[] children;
    [System.Obsolete]
    private void Start()
    {
        rend = GetComponent<LineRenderer>();
        rend.useWorldSpace = false;
        rend.SetWidth(0.02f, 0.02f);
        children = gameObject.GetComponentsInChildren<Transform>();
        rend.positionCount = children.Length - 1;
        for (int i = 1; i < children.Length; i++) rend.SetPosition(i - 1, children[i].position);
    }
}