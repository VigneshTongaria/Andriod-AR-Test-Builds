using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AMHandle3 : MonoBehaviour
{
    public TMP_Text element;
    public TMP_Text symbol;
    int index = 0;
    Dictionary<int, List<string>> data;
    private void Start()
    {
        data = new Dictionary<int, List<string>>();
        data.Add(0, new List<string> { "Aluminium", "Al" });
        data.Add(1, new List<string> { "Argon", "Ar" });
        data.Add(2, new List<string> { "Barium", "Ba" });
        data.Add(3, new List<string> { "Boron", "B" });
        data.Add(4, new List<string> { "Bromine", "Br" });
        data.Add(5, new List<string> { "Calcium", "Ca" });
        data.Add(6, new List<string> { "Carbon", "C" });
        data.Add(7, new List<string> { "Chlorine", "Cl" });
        data.Add(8, new List<string> { "Cobalt", "Co" });
        data.Add(9, new List<string> { "Copper", "Cu" });
        data.Add(10, new List<string> { "Fluorine", "F" });
        data.Add(11, new List<string> { "Gold", "Au" });
        data.Add(12, new List<string> { "Hydrogen", "H" });
        data.Add(13, new List<string> { "Iodine", "I" });
        data.Add(14, new List<string> { "Iron", "Fe" });
        data.Add(15, new List<string> { "Lead", "Pb" });
        data.Add(16, new List<string> { "Magnesium", "Mg" });
        data.Add(17, new List<string> { "Neon", "Ne" });
        data.Add(18, new List<string> { "Nitrogen", "N" });
        data.Add(19, new List<string> { "Oxygen", "O" });
        data.Add(20, new List<string> { "Potassium", "K" });
        data.Add(21, new List<string> { "Silicon", "Si" });
        data.Add(22, new List<string> { "Silver", "Ag" });
        data.Add(23, new List<string> { "Sodium", "Na" });
        data.Add(24, new List<string> { "Sulphur", "S" });
        data.Add(25, new List<string> { "Uranium", "U" });
        data.Add(26, new List<string> { "Zinc", "Zn" });
    }
    public void OnChangeDropdown(int id)
    {
        index = id;
        element.text = data[index][0];
        symbol.text = data[index][1];
    }
}