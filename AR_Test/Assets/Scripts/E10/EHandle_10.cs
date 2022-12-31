using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using TMPro;
using Lean.Transition;
using UnityEngine.UI;

public class EHandle_10 : MonoBehaviour
{
    public TMP_Text eq;
    public Image y;
    public Color[] colors;
    public GameObject sulphur;
    private int filingCount;
    public float delayOfSprinkling = 100f;
    public float max_size;
    public AudioSource[] src;
    public GameObject particle;
    public GameObject glow_object;
    public Material glow_mat;
    private void Start()
    {
        colors[2] = y.color;
    }
    public IEnumerator StartSprinkling()
    {
        while (filingCount <= max_size)
        {
            yield return new WaitForSeconds(delayOfSprinkling * Time.deltaTime);
            SprinkleIt();
            filingCount++;
            if(filingCount<=150)
            {
                float interpolationRatio = (float)filingCount / 150;
                Color interpolatedColor = Color.Lerp(colors[2], colors[0],interpolationRatio);
                y.color = interpolatedColor;
            }
            else if (filingCount > 150 && filingCount<=300)
            {
                eq.text = "Orange red color is observed at the screen";
                //y.colorTransition(colors[1], 8f, LeanEase.Smooth);
                float interpolationRatio = (float)(filingCount - 150) / 150;
                Color interpolatedColor = Color.Lerp(colors[0], colors[1], interpolationRatio);
                y.color = interpolatedColor;
            }
            else
                eq.text = "Bright crimson red color is observed at the screen";
            //Debug.Log(filingCount);
        }
        particle.SetActive(false);
        src[1].Stop();
        glow_object.SetActive(false);
        y.color = colors[2];
    }
    public void SprinkleIt()
    {
        Vector3 temp = Random.insideUnitSphere * 0.07f;
        Instantiate(sulphur, new Vector3(0.015f + temp.x, 0.807f, temp.z), Quaternion.identity);
    }
    public void PowerControl()
    {
        eq.text = "Sulphur particles are forming and precipitating in the solution";
        src[0].Play();
        src[1].Play();
        particle.SetActive(true);
        StartCoroutine(StartSprinkling());
        //y.colorTransition(colors[0], 8f, LeanEase.Smooth);
        glow_object.SetActive(true);
    }
    public void Update()
    {
        glow_mat.SetVector("_EmissionColor", new Vector4(0f, 145f, 191f, 1f) * Mathf.PingPong(Time.time/30, 0.05f));
    }
}
