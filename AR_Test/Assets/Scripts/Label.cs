using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Label : MonoBehaviour
{
    GameObject labelPrefab;
    Vector3 labelPosition;
    BoxCollider box;
    [SerializeField]
    float yOffset = 0.25f;
    [SerializeField]
    string labelString = "NOT ASSIGNED";
    GameObject temp;
    bool _labelVisible = false;
    GameObject labelCanvas;
    float adjust_width = 0.02f;
    GameObject labelObj; // new
    private void Awake()
    {
        labelPrefab = Resources.Load("Label_Prefab_Small") as GameObject;
        labelCanvas = GameObject.Find("/Label_Canvas");
        box = GetComponent<BoxCollider>(); //be aware that there should be only one box collider on this object
        labelPosition = new Vector3(transform.position.x, box.bounds.max.y + yOffset, transform.position.z);
    }
    public void Show()
    {
        labelObj = Instantiate(labelPrefab, labelPosition, Quaternion.identity);
        temp = labelObj;
        labelObj.GetComponentInChildren<TMP_Text>().text = labelString;
        Transform bg = labelObj.transform.Find("Label/Background");
        if (bg != null) bg.gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(adjust_width * (int)labelString.Length, bg.gameObject.GetComponent<Image>().rectTransform.sizeDelta.y);
        else Debug.Log("No child with the name 'Background' attached to the labelObj");
        labelObj.transform.SetParent(labelCanvas.transform, false);
    }
    public void Hide()
    {
        if (temp != null)
        {
            temp.GetComponent<Animator>().SetTrigger("close");
            Destroy(temp, 0.4f);
        }
    }
    public void OnButtonClick()
    {
        if (_labelVisible)
        {
            Hide();
            _labelVisible = false;
        }
        else
        {
            Show();
            _labelVisible = true;
        }
    }
    private void Update()
    {
        labelPosition = new Vector3(transform.position.x, box.bounds.max.y + yOffset, transform.position.z); // new
        if(labelObj!=null) labelObj.transform.position = labelPosition; // new
    }
}
