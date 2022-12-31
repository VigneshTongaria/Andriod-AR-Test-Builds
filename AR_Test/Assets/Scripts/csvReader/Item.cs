using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string description;
    public string lelement;
    public string relement;
    public string lvalency;
    public string rvalency;

    public Item(Item d)
    {
        id = d.id;
        description = d.description;
        lelement = d.lelement;
        relement = d.relement;
        lvalency = d.rvalency;
        rvalency = d.rvalency;
    }
}