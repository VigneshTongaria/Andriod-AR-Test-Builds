using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;

public class EHandle_4 : MonoBehaviour
{
    public GameObject[] volt;
    public Lean.Gui.LeanToggle[] but;
    public TMP_Text eq;
    public TMP_Text[] voltmeter;

    bool PowerToogleButton;
    public AudioSource src;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;

    public void ShowAm(int x)
    {
        volt[x].SetActive(true);
    }
    public void HideAm(int x)
    {
        volt[x].SetActive(false);
    }
    public void SetText(float value)
    {
        for (int i = 0; i < voltmeter.Length; i++)
            voltmeter[i].text = (value * (i + 1)).ToString("F2");
        voltmeter[3].text = (value * 6).ToString("F2");
        voltmeter[4].text = value.ToString("F2");
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
            plug.position = pos[1].position;
            plug.rotation = pos[1].rotation;
            powerText.text = "Off";
            eq.text = "V = 6V\nV1 = IR1 = 1V\nV2 = IR2 = 2V\nV3 = IR3 = 3V\nV = V1 + V2 + V3 = 6V\nIR = IR1 + IR2 + IR3\nR = R1 + R2 + R3";
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
