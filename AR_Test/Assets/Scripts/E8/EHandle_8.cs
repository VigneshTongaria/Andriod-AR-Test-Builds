using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EHandle_8 : MonoBehaviour
{
    public LineRenderer[] lines;
    public Transform[] top;
    public Transform[] bottom;
    public Transform[] candle;
    public TMP_Text value;
    public Transform lens;
    private int ind;
    public GameObject convexLens;
    bool lensActive;
    public Lean.Gui.LeanToggle[] but;
    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            lines[0].SetPosition(i, top[i].position);
            lines[1].SetPosition(i, bottom[i].position);
        }
        if (ind == 1 && !lensActive && candle[0].position.x > -0.563f)
            candle[1].position = new Vector3(1.033f + (0.563f + candle[0].position.x) / 0.8f * 0.168f, candle[1].position.y, candle[1].position.z);
        else
            candle[1].position = new Vector3(1.033f, 1.062f, 0f);
        var x = 0;
        for (int i = 0; i < but.Length; i++)
        {
            x += System.Convert.ToInt32(but[i].On);
        }
        if (x == 0)
        {
            but[0].On = true;
            lensActive = false;
            convexLens.SetActive(false);
        }
    }
    public void ChangePosition(float val)
    {
        candle[0].position = new Vector3(0.237f - val * 0.16f, candle[0].position.y, candle[0].position.z);
        value.text = val.ToString("F1") + " m";
        lens.LeanScaleZ(6f - 4f * val / 10f, 0f);
    }
    public void ChangeEye(int x)
    {
        ind = x;
        lensActive = false;
        convexLens.SetActive(false);
    }
    public void PlaceLens()
    {
        lensActive = true;
        convexLens.SetActive(true);
    }
}
