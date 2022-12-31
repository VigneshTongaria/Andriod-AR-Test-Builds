using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;
    Vector3 omega;
    public bool flag;
    private void Start()
    {
        omega = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        var rand = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        var pos = Vector3.Cross(omega, rand).normalized * Random.Range(0.15f, 0.6f); // 0.3,1.2
        transform.GetChild(0).transform.position = transform.position + pos;
    }
    void Update()
    {
        if(flag) transform.Rotate(omega * rotationSpeed * Time.deltaTime);
    }
}
