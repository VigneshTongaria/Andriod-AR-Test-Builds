using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal5 : MonoBehaviour
{
    public ElectronHandle5 eh;
    public GameObject[] buttons;
    public TMP_Text element;
    List<string> names;
    public SoundA1 src;
    public void Start()
    {
        names = new List<string>();
        names.Add("Hydrogen");
        names.Add("Helium");
        names.Add("Lithium");
        names.Add("Beryllium");
        names.Add("Boron");
        names.Add("Carbon");
        names.Add("Nitrogen");
        names.Add("Oxygen");
        names.Add("Fluorine");
        names.Add("Neon");
        names.Add("Sodium");
        names.Add("Magnesium");
        names.Add("Aluminium");
        names.Add("Silicon");
        names.Add("Phosphorus");
        names.Add("Sulfur");
        names.Add("Chlorine");
        names.Add("Argon");

    }
    public void Change()
    {
        eh.ChangeAtom();
    }
    public void ShowButtons()
    {
        foreach (GameObject butn in buttons)
            butn.SetActive(true);
    }
    public void PlayOpen()
    {
        element.text = names[eh.atomicNumber - 1];
        src.PlayClip(7, true, false);
    }
    public void PlayClose()
    {
        src.PlayClip(8, true, false);
    }
}
