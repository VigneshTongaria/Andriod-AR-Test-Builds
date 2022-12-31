using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lean.Transition;

public class AHandle_2 : MonoBehaviour
{
    Dictionary<int, List<string>> data, newdata; // index::change::nature
    public TMP_Text log;
    public Animator[] anim;
    public GameObject[] objs;
    public int index = 0;
    public GameObject[] liqs;
    public Material[] mats;
    public TMP_Text notifText;
    public GameObject notif;
    public Image notifImage;
    int notifCount = 0;
    Vector2 originalScale;
    public SoundA1 src;
    public bool flag = true; // mixing the solution
    bool flag2 = false; // for log
    bool flag3 = false; // for lerping color
    float startTime; // for lerping color
    public Bottle bot;
    public Color[] cols;
    void Start()
    {
        data = new Dictionary<int, List<string>>();
        newdata = new Dictionary<int, List<string>>();

        data.Add(0, new List<string> { "Lemon juice", "No change", "Acidic" });
        data.Add(1, new List<string> { "Orange juice", "No change", "Acidic" });
        data.Add(2, new List<string> { "Vinegar", "No change", "Acidic" });
        data.Add(3, new List<string> { "Milk of magnesia", "Red", "Basic" });
        data.Add(4, new List<string> { "Baking soda", "Red", "Basic" });
        data.Add(5, new List<string> { "Lime water", "Red", "Basic" });
        data.Add(6, new List<string> { "Sugar", "No change", "Neutral" });
        data.Add(7, new List<string> { "Common salt", "No change", "Neutral" });

        for (int i = 0; i < 8; i++)
        {
            newdata.Add(i, new List<string>(data[i]));
        }
        for (int i = 0; i < 8; i++)
            for (int j = 1; j <= 2; j++)
                newdata[i][j] = "-";
        UpdateLog();
        originalScale = notifImage.rectTransform.sizeDelta;
    }
    private void Update()
    {
        if(flag3)
        {
            float t = (Time.time - startTime) / 6f;
            liqs[2].GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[1], t);
        }
    }
    public void ChangeStatus(int index)
    {
        newdata[index][1] = data[index][1];
        newdata[index][2] = data[index][2];
        UpdateLog();
    }
    void UpdateLog()
    {
        string temp = "Substance\t\t\t\t\tEffect on turmeric solution\t\t\t";
        if (flag2) temp += "\t";
        temp += "Nature\n";
        for (int i = 0; i < 8; i++)
        {
            int space1 = 24 - newdata[i][0].Length;
            int space2 = 24 - newdata[i][1].Length;
            for (int j = 0; j < 3; j++)
            {
                temp += newdata[i][j];
                if (j == 0)
                    for (int k = 0; k < space1; k++)
                        temp += " ";
                else if(j==1)
                    for (int k = 0; k < space2; k++)
                        temp += " ";
                if(j!=2) temp += "\t\t\t\t";
                if (j == 1 && (i == 3 || i == 4 || i == 5) && newdata[i][1] != "-") temp += "\t";
                if (i == 6 && j == 0) temp += "\t";
                if (j == 1 && flag2 && newdata[i][1]=="-") temp += "\t";
            }
            temp += "\n";
        }
        log.text = temp;
    }
    public void Pour()
    {
        anim[0].SetTrigger("Pour");
        objs[0].SetActive(false);
        objs[1].SetActive(false);
        objs[3].SetActive(false);
    }
    public void Reset()
    {
        objs[0].SetActive(true);
        objs[1].SetActive(true);
        objs[2].SetActive(false);
        objs[3].SetActive(true);
        flag = true;
        flag3 = false;
        anim[0].SetTrigger("Restart");
        anim[1].SetTrigger("Restart");
        bot.y[0] = true;
        bot.y[3] = true;
        liqs[2].GetComponent<Renderer>().material.color = cols[0];
    }
    public void OnChangeSolution(int id)
    {
        index = id;
        liqs[0].GetComponent<MeshRenderer>().material = mats[index];
        liqs[1].GetComponent<MeshRenderer>().material = mats[index];
    }
    public void AddSolution()
    {
        if (data[index][1] == "No change")
        {
            //no change
        }
        else if(data[index][1] == "Red")
        {
            flag3 = true;
            startTime = Time.time;
        }
        if (newdata[index][1] == "-")
        {
            flag2 = true;
            ChangeStatus(index);
            notifCount++;
            notifText.text = notifCount.ToString();
            notif.SetActive(true);
            notifImage.rectTransform.sizeDeltaTransition(originalScale * 1.5f, 0.2f).JoinTransition().sizeDeltaTransition(originalScale, 0.2f);
            src.PlayClip(2, true, false);
        }
    }
    public void CloseNotif()
    {
        notifCount = 0;
        notif.SetActive(false);
    }
}
