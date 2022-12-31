using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;
using UnityEngine.SceneManagement;

public class EHandle_11 : MonoBehaviour
{
    public GameObject compass;
    public GameObject bulb;
    public GameObject liquid;
    public Material[] mat;

    public Transform needle;
    Light bulb_light;

    public Lean.Gui.LeanToggle[] but;
    public TMP_Text eq;

    bool PowerToogleButton;
    public AudioSource src;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;
    private int ind;

    string scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        if (scene == "E11") bulb.SetActive(true);
        else compass.SetActive(true);
        bulb_light = GetComponent<Light>();
    }

    public void ChangeLiquid(int x)
    {
        liquid.GetComponent<MeshRenderer>().material = mat[x];
        ind = x;
        if (PowerToogleButton)
        {
            ChangeText();
        }
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
    private void ChangeText()
    {
        if (ind == 0 || ind == 1 || ind == 2 || ind == 5)
        {
            if (scene == "E11")
            {
                eq.text = "Bulb glows";
                bulb_light.intensityTransition(1f, 0.5f, LeanEase.Smooth);
            }
            else
            {
                eq.text = "Deflection in needle occured";
                needle.localRotationTransition(Quaternion.Euler(new Vector3(0f, -90f, 90f)), 0.5f, LeanEase.Smooth);
            }
        }
        else
        {
            if (scene == "E11")
            {
                eq.text = "Bulb doesn't glow";
                bulb_light.intensityTransition(0f, 0.5f, LeanEase.Smooth);
            }
            else
            {
                eq.text = "No Deflection in needle";
                needle.localRotationTransition(Quaternion.Euler(new Vector3(-90f, -90f, 90f)), 0.5f, LeanEase.Smooth);
            }
        }
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            plug.position = pos[1].position;
            plug.rotation = pos[1].rotation;
            powerText.text = "Off";
            ChangeText();
        }
        else
        {
            PowerToogleButton = false;
            plug.position = pos[0].position;
            plug.rotation = pos[0].rotation;
            powerText.text = "On";
            eq.text = "Please plug the key to start the experiment";
            if (scene == "E11") bulb_light.intensityTransition(0f, 0.5f, LeanEase.Smooth);
            else needle.localRotationTransition(Quaternion.Euler(new Vector3(-90f, -90f, 90f)), 0.5f, LeanEase.Smooth);
        }
        src.Play();
    }
}
