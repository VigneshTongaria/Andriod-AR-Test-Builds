using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Dropper5 : MonoBehaviour
{
    public AHandle_5 ah;
    public Animator dropAnim;
    public void ChangeColor(int x)
    {
        switch (x)
        {
            case 0:ah.Acidic();
                break;
            case 1:ah.Basic();
                break;
            default:
                break;
        }
    }
    public void Step1()
    {
        ah.Step1();
    }
    public void Step2()
    {
        ah.Step2();
    }
    public void Fill(float fill)
    {
        ah.tts.transform.LeanScaleY(fill, 0.4f);
    }
    public void Drop()
    {
        dropAnim.SetTrigger("Drop");
    }
}
