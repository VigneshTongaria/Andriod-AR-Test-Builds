using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Transition;
using System;

public class AHandle_5 : MonoBehaviour
{
    public Animator DropperAnim;
    public Animator[] Toasts;
    public TMP_Text[] toastTexts;
    public GameObject[] objs;
    public int index = 1;
    public GameObject tts; //test tube solution
    public TMP_Text screenText;
    public SoundA1 src;
    bool flag3 = false; // for lerping color
    bool flag4 = false; // false=>colorless , true=>pink
    float startTime; // for lerping color
    public Color[] cols;
    public GameObject[] buts;
    int acidDrops, baseDrops;
    void Start()
    {
        index = 1;
        cols[0] = tts.GetComponent<Renderer>().material.color;
        acidDrops = baseDrops = 0;
    }
    private void Update()
    {
        if (flag3)
        {
            float t = (Time.time - startTime);
            if (!flag4) tts.GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[1], t);
            else tts.GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[2], t);
        }
    }
    public IEnumerator Toast(Animator toast, float stayTime)
    {
        toast.SetTrigger("Open");
        src.PlayClip(4, true, false);
        yield return new WaitForSeconds(stayTime);
        toast.SetTrigger("Close");
        src.PlayClip(5, true, false);
    }
    public void DropLiquid(int test)
    {
        switch (test)
        {
            case 1: DropperAnim.SetTrigger("Red");
                break;
            case 2: DropperAnim.SetTrigger("Blue");
                break;
            default:
                break;
        }
    }
    public void RemoveObjs()
    {
        foreach (GameObject obj in objs)
            obj.SetActive(false);
        ChangeText(1);
        ResetTrigger();
    }
    public void Acidic()
    {
        acidDrops++;
        toastTexts[0].text = acidDrops.ToString();
        StartCoroutine(Toast(Toasts[0],2f));
        ChangeColor();
    }
    public void Basic()
    {
        baseDrops++;
        toastTexts[1].text = baseDrops.ToString();
        StartCoroutine(Toast(Toasts[0], 2f));
        ChangeColor();
    }
    void ChangeColor()
    {
        flag3 = true;
        startTime = Time.time;
        flag4 = (baseDrops >= acidDrops + 5);
        cols[0] = tts.GetComponent<Renderer>().material.color;
        if (baseDrops >= acidDrops + 5) ChangeText(2);
        else ChangeText(0);
    }
    void ResetTrigger()
    {
        Toasts[0].ResetTrigger("Restart");
        Toasts[0].ResetTrigger("Close");
    }
    public void ChangeText(int x)
    {
        var temp = "Testube solution is: ";
        if (x == 3) screenText.text = "Please add phenolphthalein in Test Tube";
        if (x == 2) screenText.text = temp + "Basic";
        else if(x==0) screenText.text = temp + "Acidic";
    }
    public void Step1()
    {
        ChangeText(3);
        buts[1].SetActive(true);
    }
    public void Step2()
    {
        ChangeText(0);
        buts[2].SetActive(true);
        buts[3].SetActive(true);
    }
}