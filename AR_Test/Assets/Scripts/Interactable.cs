using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void Update()
    {
        Highlight();
    }
    private void Highlight()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform != null)
            {
                //Debug.Log(hit.transform.gameObject.name);
                if(hit.transform == transform) gameObject.GetComponent<Outline>().enabled = true;
                else gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
