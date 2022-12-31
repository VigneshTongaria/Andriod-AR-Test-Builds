using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lean.Transition;

public class Flask : MonoBehaviour
{
    public TMP_Text instructionText;
    public Text buttonText;
    public GameObject reactbutton;
    public Animator Toast;
    public SoundA1 src;
    public TMP_Text weightText;
    float startTime; // for lerping color
    public GameObject liq;
    public Color[] cols;
    bool flag;
    public TMP_Text screenText;
    private void Update()
    {
        if (flag)
        {
            float t = (Time.time - startTime) / 6f;
            liq.GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[1], t);
        }
    }
    public void ShowButon()
    {
        instructionText.text = "React copper sulphate solution with sodium carbonate";
        instructionText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(930f, 50f);
        instructionText.gameObject.SetActive(true);
        reactbutton.SetActive(true);
        ChangeText(1);
    }
    public void Notify()
    {
        StartCoroutine(PlayToast(3f, Toast));
    }
    public void React()
    {
        flag = true;
        startTime = Time.time;
        StartCoroutine(DelayedPlayToast(3f, 3f, Toast));
        ChangeText(2);
    }
    public IEnumerator PlayToast(float stayTime, Animator toast)
    {
        // yield return new WaitForSeconds(1f);
        toast.SetTrigger("Open");
        src.PlayClip(4, true, false);
        yield return new WaitForSeconds(stayTime);
        toast.SetTrigger("Close");
        src.PlayClip(5, true, false);
    }
    public IEnumerator DelayedPlayToast(float delay,float stayTime, Animator toast)
    {
        yield return new WaitForSeconds(delay);
        toast.SetTrigger("Open");
        src.PlayClip(4, true, false);
        yield return new WaitForSeconds(stayTime);
        toast.SetTrigger("Close");
        src.PlayClip(5, true, false);
        ChangeText(3);
    }
    public void SetText(float value)
    {
        weightText.text = (350 + value * 150).ToString("F2");
    }
    public void IncreaseWeight()
    {
        LeanTween.value(gameObject, 0, 1, 0.2f).setOnUpdate(SetText);
    }
    public void ChangeText(int x)
    {
        if (x == 1) screenText.text = "Please click on React button to tilt and swirl the flask, so that copper sulphate solution and sodium carbonate get mixed";
        else if (x == 2) screenText.text = "Does the mass of the flask and its contents change?";
        else screenText.text = "Mass of the flask and its contents doesn't change";
    }
}
