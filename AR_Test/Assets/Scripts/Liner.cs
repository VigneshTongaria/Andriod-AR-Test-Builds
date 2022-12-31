using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Liner : MonoBehaviour {

	public Transform Object1;
	public Transform Object2;
	LineRenderer line;
	public float RopeWidth = 0.005f;

    [System.Obsolete]
    void Start () {
		if(Object1 == null || Object2 == null)
		{
			Debug.LogWarning("Please Attach Object in inspector");
			return;
		}
		line = GetComponent<LineRenderer>();
		line.SetWidth(RopeWidth,RopeWidth);
		line.useWorldSpace = true;
		line.positionCount = 2;
		line.SetPosition(0, Object1.position);
		line.SetPosition(1, Object2.position);
	}
	void Update () {

		line.SetPosition(0, Object1.position);
		line.SetPosition(1, Object2.position);
	}
}
