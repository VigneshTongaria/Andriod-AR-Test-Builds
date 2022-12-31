using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;

public class EHandle_3 : MonoBehaviour
{
    public GameObject[] wires;
    public GameObject[] amm;
    public Lean.Gui.LeanToggle[] but;
    public TMP_Text eq;
    public TMP_Text[] ammeter;

    bool PowerToogleButton;
    public AudioSource src;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;

    private int ind;
    public void ShowAm(int x)
    {
        wires[x].SetActive(false);
        amm[x].SetActive(true);
        ind = x;
        if (PowerToogleButton) eq.text = "I" + (ind + 1) + " = 1A";
    }
    public void HideAm(int x)
    {
        wires[x].SetActive(true);
        amm[x].SetActive(false);
    }
    public void SetText(float value)
    {
        foreach(TMP_Text t in ammeter)
            t.text = value.ToString("F2");
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
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            LeanTween.value(gameObject, 0, 1, 0.5f).setOnUpdate(SetText);
            eq.text = "I" + (ind + 1) + " = 1A";
            plug.position = pos[1].position;
            plug.rotation = pos[1].rotation;
            powerText.text = "Off";
        }
        else
        {
            PowerToogleButton = false;
            LeanTween.value(gameObject, 1, 0, 0.5f).setOnUpdate(SetText);
            plug.position = pos[0].position;
            plug.rotation = pos[0].rotation;
            powerText.text = "On";
            eq.text = "Please plug the key to start the experiment";
        }
        src.Play();
    }
}
