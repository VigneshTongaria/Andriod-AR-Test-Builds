using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Iron_Filing_Handler_5 : MonoBehaviour
{
    [SerializeField] AudioSource[] src;
    [SerializeField]
    AudioClip[] clips;
    private Coroutine sprinklerRoutine = null;
    private Iron_Filings_5[] filings;
    public Transform paper;

    public GameObject reverseButton;
    public bool PowerToogleButton;
    public Transform[] Cclips;
    public Vector3 pole;
    public Vector3 earthMag;

    public void ShakePaper()
    {
        paper.rotationTransition(paper.rotation * Quaternion.Euler(0f, 10f, 0f), 0.05f, LeanEase.Bounce);
        paper.JoinDelayTransition<Transform>(0f);
        paper.rotationTransition(paper.rotation * Quaternion.Euler(0f, -10f, 0f), 0.05f, LeanEase.Bounce);
        paper.JoinDelayTransition<Transform>(0f);
        paper.rotationTransition(paper.rotation * Quaternion.Euler(0f, 0f, 0f), 0.05f, LeanEase.Bounce);
        if (!PowerToogleButton) return;
        if (clips.Length != 2) return;
        src[0].clip = clips[0];
        src[0].Play();

        filings = GameObject.FindObjectsOfType<Iron_Filings_5>();
        for (int i = 0; i < filings.Length; i++)
        {
            filings[i].Align();
        }
    }
    public void StartSprinkle()
    {
        Magnetism mag = GameObject.FindObjectOfType<Magnetism>();
        if (mag.filingCount > 2000) return;
        if (clips.Length != 2) return;
        src[1].clip = clips[1];
        src[1].Play();
        sprinklerRoutine = mag.StartCoroutine(mag.StartSprinkling());
    }
    public void StopSprinkle()
    {
        if (sprinklerRoutine != null) StopCoroutine(sprinklerRoutine);
        src[1].Stop();
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            reverseButton.SetActive(false);
        }
        else
        {
            PowerToogleButton = false;
            reverseButton.SetActive(true);
        }
    }
    public void Reverse()
    {
        Vector3 temp = Cclips[0].position;
        Cclips[0].position = Cclips[1].position;
        Cclips[1].position = temp;
        pole.y *= -1;
    }
    public void ChangeCurrent(float val)
    {
        pole.y = val;
    }
}
