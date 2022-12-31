using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASHandle_5 : MonoBehaviour
{
    public SoundA1 src;
    public Animator anim;
    bool flag1, flag2;
    public Material[] mats;
    public Color[] cols;
    float startTime1, startTime2; // for lerping color
    public ElectronHandle5 eh;
    int index;
    bool rand;
    public GameObject[] buttons;
    public void Start()
    {
        mats[0].SetVector("_EmissionColor", cols[0]);
        mats[1].SetFloat("_FillRate", 2.7f);
        index = 0;
    }
    private void Update()
    {
        if(flag1)
        {
            float t = (Time.time - startTime1) / 0.5f;
            var color = Color.Lerp(cols[0], cols[1], t);
            mats[0].SetVector("_EmissionColor", color * Mathf.Pow(2f, 5.5f * Mathf.Min(1f, t)));
        }
        if(flag2)
        {
            float t = (Time.time - startTime2) / 0.5f;
            if (t > 1) flag2 = false;
            mats[1].SetFloat("_FillRate", 2.7f - t * 1.6f);
        }
    }
    public void Open(int x)
    {
        if ((index == 1 && x == -1) || (index == 18 && x == 1)) return;
        foreach (GameObject butn in buttons)
            butn.SetActive(false);
        index += x;
        eh.atomicNumber = index;
        if (!rand)
        {
            src.PlayClip(6, true, false);
            flag2 = true;
            startTime2 = Time.time;
            StartCoroutine(SetTrue());
            rand = true;
        }
        else anim.SetTrigger("Close");
        return;
    }
    IEnumerator SetTrue()
    {
        yield return new WaitForSeconds(0.35f);
        src.PlayClip(7, true, false);
        anim.SetTrigger("Open");
        flag1 = true;
        startTime1 = Time.time;
    }
}
