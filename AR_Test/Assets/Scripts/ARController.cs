using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject myObject;
    public ARRaycastManager raycastManager;
    private bool flag;
    public void Update()
    {
        if(!flag)
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> touches = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if(touches.Count > 0)
            {
                GameObject.Instantiate(myObject, touches[0].pose.position, touches[0].pose.rotation);
                    flag = true;
            }
        }
    }
}
