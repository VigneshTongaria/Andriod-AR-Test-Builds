using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    float timer;
    bool flag;
    int[] time = { 0, 0, 0, 0 };
    int type = 1;
    public TMP_Text timeText;

    private void Update()
    {
        if (flag) timer += Time.deltaTime;
        else timer = 0f;
        MakeTime();
        if (type == 1)
        {
            if (timer < 56) MakeTime();
            else timeText.text = "56:00";
        }
        else if (type == 2)
        {
            if (timer < 36) MakeTime();
            else timeText.text = "36:00";
        }
        else
        {
            if (timer < 10) MakeTime();
            else timeText.text = "10:00";
        }
    }
    private void MakeTime()
    {
        int seconds = (int)timer;
        int msec = (int)(timer * 100 - seconds * 100);
        string s1, s2;
        if (seconds / 10 == 0) s1 = "0" + seconds.ToString();
        else s1 = seconds.ToString();
        if (msec / 10 == 0) s2 = "0" + msec.ToString();
        else s2 = msec.ToString();
        timeText.text = s1 + ":" + s2;
    }
    public void SetFlag(bool x)
    {
        flag = x;
        if (flag == false) timer = 0f;
    }
    public void SetType(int x)
    {
        type = x;
    }
}
