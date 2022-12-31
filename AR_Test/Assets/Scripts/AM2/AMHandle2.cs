using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AMHandle2 : MonoBehaviour
{
    public TMP_Text element;
    public Image symbol;
    public Sprite[] symbols;
    int index = 0;
    public void OnChangeSolution(int id)
    {
        index = id;
        symbol.sprite = symbols[index];
        element.text = symbols[index].name;
    }
}
