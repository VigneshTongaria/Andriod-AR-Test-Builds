using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lean.Transition;

public class AHandle_3 : MonoBehaviour
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
    bool flag3 = false; // for lerping color
    bool flag4 = false; // false=>green , true=>pink
    float startTime; // for lerping color
    public Bottle3 bot;
    public Color[] cols;
    public TMP_Text screenText;
    void Start()
    {
        data = new Dictionary<int, List<string>>();
        newdata = new Dictionary<int, List<string>>();

        data.Add(0, new List<string> { "Shampoo (dilute solution)", "Green", "Basic" });
        data.Add(1, new List<string> { "Lemon juice", "Pink", "Acidic" });
        data.Add(2, new List<string> { "Soda water", "Pink", "Acidic" });
        data.Add(3, new List<string> { "Sodium hydrogen carbonate", "Green", "Basic" });
        data.Add(4, new List<string> { "Vinegar", "Pink", "Acidic" });
        data.Add(5, new List<string> { "Sugar solution", "No change", "Neutral" });
        data.Add(6, new List<string> { "Common salt solution", "No change", "Neutral" });

        for (int i = 0; i < 7; i++)
        {
            newdata.Add(i, new List<string>(data[i]));
        }
        for (int i = 0; i < 7; i++)
            for (int j = 1; j <= 2; j++)
                newdata[i][j] = "-";
        UpdateLog();
        originalScale = notifImage.rectTransform.sizeDelta;
        cols[0] = mats[index].color;
    }
    private void Update()
    {
        if(flag3)
        {
            float t = (Time.time - startTime) / 6f;
            if (!flag4) liqs[0].GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[1], t);
            else liqs[0].GetComponent<Renderer>().material.color = Color.Lerp(cols[0], cols[2], t);
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
        string temp = "Substance\t\t\t\t\tEffect on turmeric solution\t\t\tNature\n";
        for (int i = 0; i < 7; i++)
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
                if (i == 0 && j == 0) temp += "\t\t\t";
                else if((i== 5 || i == 6) && newdata[i][1]!="-")
                {
                    if (j == 1) temp += "\t\t\t";
                    else if (j == 0) if (i == 5) temp += "\t\t\t\t";
                        else temp += "\t\t\t";
                }
                else if (j == 0) if (i == 3 || i == 6) temp += "\t\t\t";
                    else temp += "\t\t\t\t";
                else if (j == 1) temp += "\t\t\t\t";
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
        objs[2].SetActive(false);
    }
    public void Reset()
    {
        objs[0].SetActive(true);
        objs[1].SetActive(true);
        objs[2].SetActive(true);
        objs[3].SetActive(false);
        flag = true;
        flag3 = false;
        anim[0].SetTrigger("Restart");
        anim[1].SetTrigger("Restart");
        anim[2].SetTrigger("Restart");
        bot.y[0] = true;
        bot.y[3] = true;
        liqs[0].GetComponent<Renderer>().material.color = cols[0];
        ChangeText(0);
    }
    public void OnChangeSolution(int id)
    {
        index = id;
        liqs[0].GetComponent<MeshRenderer>().material = mats[index];
        liqs[3].GetComponent<MeshRenderer>().material = mats[index];
        cols[0] = mats[index].color;
    }
    public void AddIndicator()
    {
        if (data[index][1] == "No change")
        {
            //no change
        }
        else
        {
            flag3 = true;
            startTime = Time.time;
            flag4 = (data[index][1] == "Pink");
        }
        if (newdata[index][1] == "-")
        {
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
    public void ChangeText(int x)
    {
        if (x == 1) screenText.text = "Substance: " + data[index][0];
        else screenText.text = "Please select a substance to start the experiment";
    }
}
