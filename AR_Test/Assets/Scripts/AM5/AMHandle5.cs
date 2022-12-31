using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AMHandle5 : MonoBehaviour
{
    public TMP_Text description,lelement, relement, lvalency, rvalency, _lelement,_relement, _lvalency, _rvalency;
    public LoadExcel database;
    public Animator anim;
    public int index;
    private void Start()
    {
        database.GetComponent<LoadExcel>().LoadItemData();
    }
    public void OnChangeDropdown(int id)
    {
        index = id;
    }
    public void Show()
    {
        description.text = "Formula of " + database.itemDatabase[index].description;
        lelement.text = database.itemDatabase[index].lelement;
        relement.text = database.itemDatabase[index].relement;
        lvalency.text = database.itemDatabase[index].lvalency;
        rvalency.text = database.itemDatabase[index].rvalency;
        _lelement.text = database.itemDatabase[index].lelement;
        _relement.text = database.itemDatabase[index].relement;
        var x = int.Parse(database.itemDatabase[index].lvalency, System.Globalization.NumberStyles.Integer);
        var y = int.Parse(database.itemDatabase[index].rvalency, System.Globalization.NumberStyles.Integer);
        _lvalency.text = (Mathf.Abs(y) == 1) ? "" : y.ToString();
        _rvalency.text = (Mathf.Abs(x) == 1) ? "" : x.ToString();
        anim.SetTrigger("Show");
    }
}