using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;
using UnityEngine.SceneManagement;

public class EHandle_13 : MonoBehaviour
{
    public GameObject[] particle;
    public TMP_Text eq;

    bool PowerToogleButton;
    public AudioSource src;
    public AudioSource bubbleSrc;
    public Transform[] pos;
    public Transform plug;
    public TMP_Text powerText;

    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            plug.position = pos[1].position;
            plug.rotation = pos[1].rotation;
            powerText.text = "Off";
            eq.text = "Bubbles are formed";
            foreach (GameObject p in particle) p.SetActive(true);
            bubbleSrc.Play();
        }
        else
        {
            PowerToogleButton = false;
            plug.position = pos[0].position;
            plug.rotation = pos[0].rotation;
            powerText.text = "On";
            eq.text = "Please plug the key to start the experiment";
            foreach (GameObject p in particle) p.SetActive(false);
            bubbleSrc.Stop();
        }
        src.Play();
    }
}
