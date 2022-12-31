using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronHandle5 : MonoBehaviour
{
    public int atomicNumber;
    List<GameObject> electrons;
    public GameObject electronPrefab;
    public Transform model;
    private void Start()
    {
        electrons = new List<GameObject>();
        atomicNumber = 0;
        MakeNewModel();
    }
    public void ChangeAtom()
    {
        foreach (GameObject electron in electrons)
            Destroy(electron);
        electrons.Clear();
        MakeNewModel();
    }
    void MakeNewModel()
    {
        List<int> shell = new List<int>();
        var x = atomicNumber;
        shell.Insert(0, Mathf.Min(x, 2));
        x -= 2;
        shell.Insert(1, Mathf.Min(x, 8));
        x -= 8;
        shell.Insert(2, Mathf.Min(x, 18));
        for (int i = 0; i < 3; i++)
        {
            if (shell[i] <= 0) continue;
            for (int j = 0; j < shell[i]; j++)
            {
                GameObject elec = Instantiate(electronPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                electrons.Add(elec);
                elec.transform.SetParent(model);
                elec.transform.localPosition = new Vector3(0f, 0f, 0f);
                if(i==0) elec.transform.GetChild(0).localPosition = new Vector3(1.672f*Mathf.Cos(2*3.14f*j/shell[i]), 0f, 1.672f* Mathf.Sin(2 * 3.14f * j / shell[i]));
                else if(i==1) elec.transform.GetChild(0).localPosition = new Vector3(2.527f * Mathf.Cos(2 * 3.14f * j / shell[i]), 0f, 2.527f * Mathf.Sin(2 * 3.14f * j / shell[i]));
                else elec.transform.GetChild(0).localPosition = new Vector3(3.365f * Mathf.Cos(2 * 3.14f * j / shell[i]), 0f, 3.365f * Mathf.Sin(2 * 3.14f * j / shell[i]));
                elec.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
