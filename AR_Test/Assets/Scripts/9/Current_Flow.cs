using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current_Flow : MonoBehaviour
{
    public List<Transform> wayPointList  = new List<Transform>();
    public int currentWayPoint = 0;
    public float speed = 4f;
    private void Start()
    {
        GameObject[] wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        foreach (GameObject child in wayPoints)
            wayPointList.Add(child.transform);
        wayPointList.Sort(delegate (Transform a, Transform b)
        {
            return string.Compare(a.name, b.name);
        });
    }
    private void Update()
    {
        currentWayPoint %= wayPointList.Count;
        walk();
    }
    void walk()
    {
        //transform.forward = Vector3.RotateTowards(transform.forward, wayPointList[currentWayPoint].position - transform.position, speed * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, wayPointList[currentWayPoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPointList[currentWayPoint].position) < 0.0001f)
        {
            transform.position = wayPointList[currentWayPoint].position;
            currentWayPoint++;
        }
    }
}
