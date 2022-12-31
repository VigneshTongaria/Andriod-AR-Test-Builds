using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper4 : MonoBehaviour
{
    public AHandle_4 ah;
    public GameObject nextButton;
    public void ChangeColor(int x)
    {
        switch (x)
        {
            case 0:ah.RedLitmus();
                break;
            case 1:ah.BlueLitmus();
                break;
            case 2:ah.Turmeric();
                break;
            case 3:ah.ChinaRose();
                break;
            default:
                break;
        }
    }
    public void ShowNext()
    {
        nextButton.SetActive(true);
    }
}
