using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;

public class IronFilingHandler : MonoBehaviour
{
    [SerializeField] AudioSource[] src;
    [SerializeField]
    AudioClip[] clips;
    private Coroutine sprinklerRoutine = null;
    private IronFilings[] filings;

    public void ShakePaper()
    {
        if (clips.Length != 2) return;
        src[0].clip = clips[0];
        src[0].Play();

        filings = GameObject.FindObjectsOfType<IronFilings>();
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
}
