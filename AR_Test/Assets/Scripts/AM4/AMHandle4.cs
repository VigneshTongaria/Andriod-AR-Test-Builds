using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AMHandle4 : MonoBehaviour
{
    public TMP_Text element;
    public TMP_Text symbol;
    int index = 0;
    Dictionary<int, List<string>> data;
    private void Start()
    {
        data = new Dictionary<int, List<string>>();
        data.Add(0, new List<string> { "Hydrogen", "1" });
        data.Add(1, new List<string> { "Carbon", "12" });
        data.Add(2, new List<string> { "Nitrogen", "14" });
        data.Add(3, new List<string> { "Oxygen", "16" });
        data.Add(4, new List<string> { "Sodium", "23" });
        data.Add(5, new List<string> { "Magnesium", "24" });
        data.Add(6, new List<string> { "Sulphur", "32" });
        data.Add(7, new List<string> { "Chlorine", "35.5" });
        data.Add(8, new List<string> { "Calcium", "40" });
    }
    public void OnChangeDropdown(int id)
    {
        index = id;
        element.text = data[index][0];
        symbol.text = data[index][1];
    }
}
