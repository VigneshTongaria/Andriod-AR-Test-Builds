using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;

public class EHandle_2 : MonoBehaviour
{
    public GameObject[] wires;
    public Lean.Gui.LeanToggle[] but;
    private float A;
    public TMP_Text eq;
    public TMP_Text ammeter;
    private float val;
    bool PowerToogleButton;
    public AudioSource src;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;
    public float[] values;
    public int[] length;
    public int[] area;
    int index;
    private void Start()
    {
        ShowWire(0);
    }
    public void ShowWire(int x)
    {
        wires[x].SetActive(true);
        A = values[x];
        index = x;
        UpdateText();
        if (PowerToogleButton) LeanTween.value(gameObject, val, A, 0.5f).setOnUpdate(SetText);
        val = A;
    }
    public void HideWire(int x)
    {
        wires[x].SetActive(false);
    }
    public void SetText(float value)
    {
        ammeter.text = (value <= 10f) ? value.ToString("F2") : value.ToString("F0");
    }
    private void Update()
    {
        var x = 0;
        for (int i = 0; i < but.Length; i++)
        {
            x += System.Convert.ToInt32(but[i].On);
        }
        if (x == 0) but[0].On = true;
    }
    private void UpdateText()
    {
        if (PowerToogleButton) eq.text = "L = " + length[index] + "l\nA = " + area[index] + "a\nI = " + A + "A";
        else eq.text = "Please plug the key to start the experiment";
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            LeanTween.value(gameObject, 0, A, 0.5f).setOnUpdate(SetText);
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
