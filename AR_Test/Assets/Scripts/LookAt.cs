using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform cam;
    private void Start()
    {
        cam = Camera.main.gameObject.transform;
    }
    private void Update()
    {
        Vector3 projectedPos = new Vector3(cam.position.x, transform.position.y, cam.position.z);
        transform.LookAt(projectedPos);
    }
}
