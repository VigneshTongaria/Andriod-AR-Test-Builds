using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadExcel : MonoBehaviour
{
    public Item blankItem;
    public List<Item> itemDatabase = new List<Item>();

    public void LoadItemData()
    {
        itemDatabase.Clear();

        List<Dictionary<string, object>> data = CSVReader.Read("CompundsDatabase");
        for(var i=0;i<data.Count;i++)
        {
            int id = int.Parse(data[i]["id"].ToString(), System.Globalization.NumberStyles.Integer);
            string description = data[i]["description"].ToString();
            string lelement = data[i]["left element"].ToString();
            string relement = data[i]["right element"].ToString();
            string lvalency = data[i]["left valency"].ToString();
            string rvalency = data[i]["right valency"].ToString();

            AddItem(id, description, lelement, relement, lvalency, rvalency);
        }
    }
    private void AddItem(int id, string description, string lelement, string relement, string lvalency, string rvalency)
    {
        Item tempItem = new Item(blankItem);
        tempItem.id = id;
        tempItem.description = description;
        tempItem.lelement = lelement;
        tempItem.relement = relement;
        tempItem.lvalency = lvalency;
        tempItem.rvalency = rvalency;

        itemDatabase.Add(tempItem);
    }
}
