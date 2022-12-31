using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    float time = 0;
    public Transform logo;
    public float tp_logo;
    private void Update()
    {
        RotateLogo();
    }
    private void RotateLogo()
    {
        time += Time.deltaTime;
        if (time>tp_logo)
        {
            logo.eulerAngles = new Vector3(logo.eulerAngles.x, logo.eulerAngles.y, logo.eulerAngles.z + 45f);
            time = 0;
        }
    }
}
