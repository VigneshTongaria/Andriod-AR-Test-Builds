using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IronFilings : MonoBehaviour
{
    GameObject _magnet;
    float mu;
    private void Start()
    {
        _magnet = FindObjectOfType<DipoleMagnet>().gameObject;
        mu = _magnet.GetComponent<DipoleMagnet>().mu;
    }
    public void Align()
    {
        Vector3 r = transform.position - _magnet.transform.position;
        Vector3 dipole = _magnet.GetComponent<DipoleMagnet>().dipoleMoment * _magnet.transform.right;
        Vector3 magneticField = (mu / (12.56f)) * (3.0f * (Vector3.Dot(dipole, r.normalized) * (r.normalized)) - dipole) / (r.magnitude * r.magnitude * r.magnitude);
        transform.LookAt(transform.position + magneticField);
        //Debug.Log(magneticField);
        //Debug.DrawLine(transform.position, transform.position + magneticField, Color.green);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "3") Align();
    }
}
