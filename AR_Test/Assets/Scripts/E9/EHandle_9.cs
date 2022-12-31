using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHandle_9 : MonoBehaviour
{
    LineRenderer rend;
    public LightRay[] lr;
    public Transform child;
    public Transform start;
    public Transform temp;
    bool power;
    public float speed;
    int index;
    public AudioSource src;
    [System.Obsolete]
    private void Start()
    {
        rend = GetComponent<LineRenderer>();
        rend.useWorldSpace = false;
        rend.SetWidth(0.02f, 0.02f);
    }
    private void Update()
    {
        if (power) ThrowLight();
    }
    public void ThrowLight()
    {
        if (index < 1 && Vector3.Distance(child.position, temp.position) < 0.01f)
        {
            index = 1;
            foreach (LightRay l in lr)
                l.SetPowerBool();
            src.Play();
        }
        if (index < 1)
        {
            temp.Translate((child.position - start.position).normalized * speed * Time.deltaTime);
            rend.SetPosition(1, temp.position);
        }
    }
    public void SetPowerBool()
    {
        if (power) return;
        rend.positionCount++;
        power = true;
    }
}
