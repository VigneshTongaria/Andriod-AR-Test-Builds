using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron_Filings_5 : MonoBehaviour
{
    Transform _magnet;
    bool PowerToogleButton;
    Iron_Filing_Handler_5 handle;
    private void Start()
    {
        _magnet = GameObject.FindGameObjectWithTag("Magnet").transform;
        handle = GameObject.FindObjectOfType<Iron_Filing_Handler_5>();
    }
    public void Align()
    {
        Vector3 r = transform.position - _magnet.transform.position;
        Vector3 magneticField = Vector3.Cross(r, handle.pole).normalized * Mathf.Exp(-10 * r.magnitude * r.magnitude) * handle.pole.magnitude;
        Vector3 dir = transform.position + magneticField + handle.earthMag * 10 * r.magnitude * r.magnitude;
        if (gameObject.name == "needle") transform.LookAt(dir);
        else transform.LookAt(transform.position + magneticField);
        //Debug.Log(magneticField);
        //Debug.DrawLine(transform.position, transform.position + magneticField, Color.green);
    }
    private void Update()
    {
        if (gameObject.name == "needle")
        {
            if(handle.PowerToogleButton) Align();
            else transform.LookAt(transform.position + handle.earthMag);
        }
    }
}
