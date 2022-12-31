using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;
using UnityEngine.SceneManagement;

public class EHandle_5 : MonoBehaviour
{
    public GameObject[] volt;
    public GameObject[] amm;
    public GameObject[] wire;

    public Lean.Gui.LeanToggle[] but;
    public TMP_Text eq;
    public TMP_Text[] ammeter;
    public TMP_Text[] voltmeter;

    bool PowerToogleButton;
    public AudioSource src;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;

    string scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    public void ShowAm(int x)
    {
        if (scene == "E5") volt[x].SetActive(true);
        else
        {
            amm[x].SetActive(true);
            wire[x].SetActive(false);
        }
    }
    public void HideAm(int x)
    {
        if (scene == "E5") volt[x].SetActive(false);
        else
        {
            amm[x].SetActive(false);
            wire[x].SetActive(true);
        }
    }
    public void SetText(float value)
    {
        for (int i = 0; i < voltmeter.Length; i++)
            voltmeter[i].text = (value * 6).ToString("F2");
        for (int i = 0; i < voltmeter.Length; i++)
            ammeter[i].text = (value * 6 / (i + 1)).ToString("F2");
        voltmeter[3].text = (value * 6).ToString("F2");
        ammeter[3].text = (value * 11).ToString("F2");
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
            if (scene == "E5") eq.text = "V = 6V\nV1 = 6V\nV2 = 6V\nV3 = 6V";
            else eq.text = "I = 11A\nI1 = 6A\nI2 = 3A\nI3 = 2A";
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
