using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;

public class EHandle_1 : MonoBehaviour
{
    public GameObject[] batteries;
    public Lean.Gui.LeanToggle[] but;
    private int V;
    public TMP_Text eq;
    public TMP_Text voltmeter;
    public TMP_Text ammeter;
    private float val;
    bool PowerToogleButton;
    public AudioSource src;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;
    private void Start()
    {
        PlaceBattery(1);
    }
    public void PlaceBattery(int x)
    {
        for(int i=0;i<batteries.Length;i++)
        {
            batteries[i].SetActive(i < x);
        }
        V = x;
        UpdateText();
        if (PowerToogleButton)
        {
            if(val!=V) LeanTween.value(gameObject, val, V, 0.5f).setOnUpdate(SetText);
            else LeanTween.value(gameObject, 0, V, 0.5f).setOnUpdate(SetText);
        }
        val = V;
    }
    public void SetText(float value)
    {
        voltmeter.text = value.ToString("F2");
        ammeter.text = value.ToString("F2");
    }
    private void Update()
    {
        var x = 0;
        for(int i=0;i<but.Length;i++)
        {
            x += System.Convert.ToInt32(but[i].On);
        }
        if (x == 0) but[0].On = true;
    }
    private void UpdateText()
    {
        if (PowerToogleButton) eq.text = "R = 1 Ohm\nV = " + V + " V\nI = " + V + " A\nR = V / I = 1";
        else eq.text = "Please plug the key to start the experiment";
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            PlaceBattery(V);
            plug.position = pos[1].position;
            plug.rotation = pos[1].rotation;
            powerText.text = "Off";
        }
        else
        {
            PowerToogleButton = false;
            LeanTween.value(gameObject, val, 0, 0.5f).setOnUpdate(SetText);
            val = 0;
            plug.position = pos[0].position;
            plug.rotation = pos[0].rotation;
            powerText.text = "On";
        }
        src.Play();
        UpdateText();
    }
}
