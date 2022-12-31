using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Transition;
using System;

public class AHandle_4 : MonoBehaviour
{
    Dictionary<int, List<string>> data, newdata; // index::red::blue
    public Animator DropperAnim;
    public Animator[] Toasts;
    public TMP_Text[] toastTexts;
    public GameObject[] objs;
    public Transform log;
    List<List<TMP_Text>> logData;
    public int index = 1;
    public Material[] mats;
    public GameObject[] RedPaper;
    public GameObject[] BluePaper;
    public GameObject[] TurmericPaper;
    public GameObject[] liqs;
    public GameObject crs; //china rose solution
    public TMP_Text screenText;
    public TMP_Text notifText;
    public GameObject notif;
    public Image notifImage;
    int notifCount = 0;
    public SoundA1 src;
    Vector2 originalScale;
    bool flag3 = false; // for lerping color
    bool flag4 = false; // false=>green , true=>pink
    float startTime; // for lerping color
    public Color[] cols;
    void Start()
    {
        data = new Dictionary<int, List<string>>();
        newdata = new Dictionary<int, List<string>>();
        logData = new List<List<TMP_Text>>();
        // Effect on Red litmus paper::Effect on Blue litmus paper::Effect on turmeric paper::Effect on China rose solution::Nature

        data.Add(0, new List<string> { "Substance", "Red litmus paper", "Blue litmus paper", "Turmeric paper", "China rose solution", "Nature" });
        data.Add(1, new List<string> { "Hydrochloric acid", "No change", "Red", "No change", "Pink", "Acidic" });
        data.Add(2, new List<string> { "Sulphuric acid", "No change", "Red", "No change", "Pink", "Acidic" });
        data.Add(3, new List<string> { "Nitric acid", "No change", "Red", "No change", "Pink", "Acidic" });
        data.Add(4, new List<string> { "Acetic acid", "No change", "Red", "No change", "Pink", "Acidic" });
        data.Add(5, new List<string> { "Sodium hydroxide", "Blue", "No change", "Red", "Green", "Basic" });
        data.Add(6, new List<string> { "Ammonium hydroxide", "Blue", "No change", "Red", "Green", "Basic" });
        data.Add(7, new List<string> { "Calcium hydroxide", "Blue", "No change", "Red", "Green", "Basic" });

        for (int i = 0; i < 8; i++)
        {
            newdata.Add(i, new List<string>(data[i]));
        }
        for (int i = 1; i < 8; i++)
            for (int j = 1; j < 6; j++)
                newdata[i][j] = "-";
        index = 1;
        InitializeLogData();
        UpdateLog();
        originalScale = notifImage.rectTransform.sizeDelta;
        cols[0] = crs.GetComponent<Renderer>().material.color;
    }
    private void Update()
    {
        if (flag3)
        {
            float t = (Time.time - startTime) / 6f;
            if (!flag4) crs.GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[1], t);
            else
            {
                crs.GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[2], t);
            }
        }
    }
    void InitializeLogData()
    {
        foreach(Transform child in log)
        {
            List<TMP_Text> temp = new List<TMP_Text>();
            foreach(Transform child2 in child)
            {
                temp.Add(child2.GetChild(0).GetComponent<TMP_Text>());
            }
            logData.Add(temp);
        }
    }

    public void ChangeStatus(int i, int j)
    {
        newdata[i][j] = data[i][j];
        if (((j==1 || j==2) && newdata[i][1] != "-" && newdata[i][2] != "-") || (j==3 && newdata[i][3] != "-") || (j==4 && newdata[i][4] != "-"))
        {
            newdata[i][5] = data[i][5];
            logData[i][5].text = newdata[i][5];
            toastTexts[0].text = "Substance is " + data[i][5];
            StartCoroutine(Toast(3f,Toasts[0]));
        }
        logData[i][j].text = newdata[i][j];
    }
    public IEnumerator Toast(float stayTime, Animator toast)
    {
        yield return new WaitForSeconds(1f);
        toast.SetTrigger("Open");
        src.PlayClip(4, true, false);
        yield return new WaitForSeconds(stayTime);
        toast.SetTrigger("Close");
        src.PlayClip(5, true, false);
    }
    void UpdateLog()
    {
        for(int i=0;i<logData.Count;i++)
        {
            for(int j=0;j<logData[0].Count;j++)
            {
                logData[i][j].text = newdata[i][j];
            }
        }
    }
    public void DropLiquid(int test)
    {
        switch (test)
        {
            case 1: DropperAnim.SetTrigger("Red");
                break;
            case 2: DropperAnim.SetTrigger("Blue");
                break;
            case 3: DropperAnim.SetTrigger("Turmeric");
                break;
            case 4: DropperAnim.SetTrigger("ChinaRose");
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
    public void ChangeSolution()
    {
        foreach (GameObject obj in objs)
            obj.SetActive(true);
        ChangeText(0);
        flag3 = false;
        crs.GetComponent<Renderer>().material.color = cols[0];
        if (!Toasts[0].GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Toasts[0].SetTrigger("Restart");
        }
        StopAllCoroutines();
    }
    public void RedLitmus()
    {
        if(data[index][1] != "No change")
        {
            RedPaper[0].transform.LeanScaleY(0.7f, 1f);
        }
        else
        {
            RedPaper[1].transform.LeanScaleY(0.7f, 1f);
        }
        if (newdata[index][1] == "-")
        {
            Notify(1);
        }
    }
    public void BlueLitmus()
    {
        if (data[index][2] != "No change")
        {
            BluePaper[0].transform.LeanScaleY(0.7f, 1f);
        }
        else
        {
            BluePaper[1].transform.LeanScaleY(0.7f, 1f);
        }
        if (newdata[index][2] == "-")
        {
            Notify(2);
        }
    }
    public void Turmeric()
    {
        if (data[index][3] != "No change")
        {
            TurmericPaper[0].transform.LeanScaleY(0.7f, 1f);
        }
        else
        {
            TurmericPaper[1].transform.LeanScaleY(0.7f, 1f);
        }
        if (newdata[index][3] == "-")
        {
            Notify(3);
        }
    }
    public void ChinaRose()
    {
        if (data[index][4] == "No change")
        {
            //no change
        }
        else
        {
            flag3 = true;
            startTime = Time.time;
            flag4 = (data[index][4] == "Pink");
        }
        if (newdata[index][4] == "-")
        {
            Notify(4);
        }
    }
    void ResetTrigger()
    {
        Toasts[0].ResetTrigger("Restart");
        Toasts[0].ResetTrigger("Close");
    }
    public void Notify(int col)
    {
        ChangeStatus(index, col);
        notifCount++;
        notifText.text = notifCount.ToString();
        notif.SetActive(true);
        notifImage.rectTransform.sizeDeltaTransition(originalScale * 1.5f, 0.2f).JoinTransition().sizeDeltaTransition(originalScale, 0.2f);
        src.PlayClip(2, true, false);
    }
    public void OnChangeSolution(int id)
    {
        index = id + 1;
        foreach (GameObject liq in liqs)
            liq.GetComponent<MeshRenderer>().material = mats[index-1];
    }
    public void ChangeText(int x)
    {
        if (x == 1) screenText.text = "Substance: " + data[index][0];
        else screenText.text = "Please select a substance to start the experiment";
    }
    public void CloseNotif()
    {
        notifCount = 0;
        notif.SetActive(false);
    }
}