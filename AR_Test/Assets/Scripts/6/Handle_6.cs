using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Handle_6 : MonoBehaviour
{
    public Transform[] lines;
    public Transform infiLine;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    public Transform[] clips;
    bool PowerToogleButton;
    public GameObject reverseButton;
    private void Update()
    {
        if (PowerToogleButton) Rotate();   
    }
    public void Reverse()
    {
        Vector3 temp = clips[0].position;
        clips[0].position = clips[1].position;
        clips[1].position = temp;
        foreach (Transform line in lines)
        {
            line.Rotate(new Vector3(0f, 180f, 0f));
        }
        infiLine.Rotate(new Vector3(180f, 0f, 0f));
    }
    private void Rotate()
    {
        foreach (Transform line in lines)
        {
            line.Rotate(_rotation * _speed * Time.deltaTime);
        }
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            reverseButton.SetActive(false);
            foreach (Transform line in lines)
            {
                line.gameObject.SetActive(true);
            }
            infiLine.gameObject.SetActive(true);
        }
        else
        {
            PowerToogleButton = false;
            reverseButton.SetActive(true);
            foreach (Transform line in lines)
            {
                line.gameObject.SetActive(false);
            }
            infiLine.gameObject.SetActive(false);
        }
    }
}
