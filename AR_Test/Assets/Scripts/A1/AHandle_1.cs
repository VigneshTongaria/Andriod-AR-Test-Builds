using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Transition;

public class AHandle_1 : MonoBehaviour
{
    Dictionary<int, List<string>> data, newdata; // index::red::blue
    public Animator DropperAnim;
    public TMP_Text log;
    public GameObject[] objs;
    public int index = 0;
    public Material[] mats;
    public GameObject[] litmusPaper;
    public GameObject[] liqs;
    public TMP_Text screenText;
    public TMP_Text notifText;
    public GameObject notif;
    public Image notifImage;
    int notifCount = 0;
    public SoundA1 src;
    Vector2 originalScale;
    void Start()
    {
        data = new Dictionary<int, List<string>>();
        newdata = new Dictionary<int, List<string>>();
        // Effect on Red litmus papre::Effect on Blue litmus paper

        data.Add(0, new List<string> { "Lemon juice solution", "No", "Yes", "Acidic" }); // lemon juice solution
        data.Add(1, new List<string> { "Tap water", "No", "Yes", "Acidic" }); // tap water
        data.Add(2, new List<string> { "Detergent solution", "Yes", "No", "Basic" }); // detergent solution
        data.Add(3, new List<string> { "Aerated drink", "No", "Yes", "Acidic" }); // aerated drink
        data.Add(4, new List<string> { "Soap solution", "Yes", "No", "Basic" }); // soap solution
        data.Add(5, new List<string> { "Shampoo", "Yes", "No", "Basic" }); // shampoo
        data.Add(6, new List<string> { "Common salt solution", "No", "No", "Neutral" }); // common salt solution
        data.Add(7, new List<string> { "Sugar solution", "No", "Yes", "Acidic" }); // sugar solution
        data.Add(8, new List<string> { "Vinegar", "No", "Yes", "Acidic" }); // vinegar
        data.Add(9, new List<string> { "Baking soda solution", "Yes", "No", "Basic" }); // baking soda solution
        data.Add(10, new List<string> { "Milk of magnesia", "Yes", "No", "Basic" }); // milk of magnesia
        data.Add(11, new List<string> { "Washing soda", "Yes", "No", "Basic" }); // washing soda
        data.Add(12, new List<string> { "Lime water", "Yes", "No", "Basic" }); // lime water

        for (int i = 0; i < 13; i++)
        {
            newdata.Add(i, new List<string>(data[i]));
        }
        for (int i = 0; i < 13; i++)
            for (int j = 1; j <= 3; j++)
                newdata[i][j] = "-";
        UpdateLog();
        originalScale = notifImage.rectTransform.sizeDelta;
    }

    public void ChangeStatus(int index, int color)
    {
        newdata[index][color] = data[index][color];
        if (newdata[index][1] != "-" && newdata[index][2] != "-") newdata[index][3] = data[index][3];
        UpdateLog();
    }
    
    void UpdateLog()
    {
        string temp = "Substance\t\t\t\t\tRed litmus paper\t\tBlue litmus paper\t\t    \tNature\n";
        for(int i=0;i<12;i++)
        {
            int space = 24 - newdata[i][0].Length;
            for (int j = 0; j < 4; j++)
            {
                temp += newdata[i][j];
                if(j==0)
                    for(int k=0;k<space;k++)
                    {
                        temp += " ";
                    }
                if (j != 3 && i!=6) temp += "\t\t\t\t";
                if (i == 6) if (j == 1 || j == 2) temp += "\t\t\t\t";
                    else if (j == 0) temp += "\t\t\t";
            }
            temp += "\n";
        }
        log.text = temp;
    }
    public void RemoveObjs()
    {
        foreach (GameObject obj in objs)
            obj.SetActive(false);
    }
    public void ChangeSolution()
    {
        foreach (GameObject obj in objs)
            obj.SetActive(true);
        ChangeText(0);
    }
    public void ChangeToBlue()
    {
        if(data[index][1]=="Yes")
        {
            litmusPaper[0].transform.LeanScaleY(0.7f, 1f);
        }
        else
        {
            litmusPaper[2].transform.LeanScaleY(0.7f, 1f);
        }
        if (newdata[index][1] == "-")
        {
            ChangeStatus(index, 1);
            notifCount++;
            notifText.text = notifCount.ToString();
            notif.SetActive(true);
            notifImage.rectTransform.sizeDeltaTransition(originalScale * 1.5f, 0.2f).JoinTransition().sizeDeltaTransition(originalScale, 0.2f);
            src.PlayClip(2, true, false);
        }
    }
    public void ChangeToRed()
    {
        if (data[index][2] == "Yes")
        {
            litmusPaper[1].transform.LeanScaleY(0.7f, 1f);
        }
        else
        {
            litmusPaper[3].transform.LeanScaleY(0.7f, 1f);
        }
        if (newdata[index][2] == "-")
        {
            ChangeStatus(index, 2);
            notifCount++;
            notifText.text = notifCount.ToString();
            notif.SetActive(true);
            notifImage.rectTransform.sizeDeltaTransition(originalScale * 1.5f, 0.2f).JoinTransition().sizeDeltaTransition(originalScale, 0.2f);
            src.PlayClip(2, true, false);
        }
    }
    public void OnChangeSolution(int id)
    {
        index = id;
        foreach (GameObject liq in liqs)
            liq.GetComponent<MeshRenderer>().material = mats[index];
    }
    public void ChangeText(int x)
    {
        if (x == 1) screenText.text = "Please select a litmus paper";
        else screenText.text = "Please select a substance to start the experiment";
    }
    public void CloseNotif()
    {
        notifCount = 0;
        notif.SetActive(false);
    }
}