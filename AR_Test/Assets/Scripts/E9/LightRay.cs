using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class LightRay : MonoBehaviour
{
    LineRenderer rend;
    Transform[] children;
    public GameObject label;
    public Transform temp;
    public float speed;
    bool power;
    int index;
    public AudioSource src;
    [System.Obsolete]
    private void Start()
    {
        rend = GetComponent<LineRenderer>();
        rend.useWorldSpace = false;
        rend.SetWidth(0.02f, 0.02f);
        children = gameObject.GetComponentsInChildren<Transform>();
        rend.positionCount = 1;
        rend.SetPosition(0, children[1].position);
        index = 1;
    }
    private void Update()
    {
        if (power) ThrowLight();
    }
    public void ThrowLight()
    {
        if (index<4 && Vector3.Distance(children[index + 1].position, temp.position) < 0.1f)
        {
            index++;
            if (index < 4)
            {
                rend.positionCount++;
                src.Play();
            }
            else label.SetActive(true);
        }
        if (index < 4)
        {
            temp.Translate((children[index + 1].position - children[index].position).normalized * speed * Time.deltaTime);
            rend.SetPosition(index, temp.position);
        }
    }
    public void SetPowerBool()
    {
        if (power) return;
        rend.positionCount++;
        power = true;
    }
}