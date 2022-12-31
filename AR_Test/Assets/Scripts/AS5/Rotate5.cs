using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate5 : MonoBehaviour
{
    public float rotationSpeed;
    Vector3 omega;
    public bool flag;
    void Update()
    {
        if (flag) transform.Rotate(new Vector3(0f, 1f, 0f) * rotationSpeed * Time.deltaTime);
    }
}
