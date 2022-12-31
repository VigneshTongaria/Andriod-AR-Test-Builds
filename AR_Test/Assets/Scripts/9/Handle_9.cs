using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Handle_9 : MonoBehaviour
{
    bool PowerToogleButton;
    public GameObject reverseButton;
    public GameObject PowerButton;
    public GameObject LoadingScreen;
    public TMP_Text loadingText;
    public Transform rot;
    private int x = 0;
    private int dots = 0;

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    public RectTransform[] forceArrows;
    public Transform[] forceArrowsAnchor;

    public int maxParticles;
    private int num_particles;
    public float interval;
    private float time;
    public GameObject particlePrefab;
    public Transform initialPos;

    private List<GameObject> particlesList = new List<GameObject>();

    public RectTransform[] labels;
    public Transform[] labelAnchors;
    private int xx = 0;

    private void Update()
    {
        if (PowerToogleButton) Rotate();
        forceArrows[0].position = forceArrowsAnchor[0].position;
        forceArrows[1].position = forceArrowsAnchor[1].position;
        float tempRot = rot.localRotation.eulerAngles.x;
        if (tempRot<90f && tempRot>89f && x==0)
        {
            RectTransform temp = forceArrows[0];
            forceArrows[0] = forceArrows[1];
            forceArrows[1] = temp;
            x = 1;
            ChangeDirection();
        }
        if (tempRot>270f && tempRot < 271f && x == 1)
        {
            RectTransform temp = forceArrows[0];
            forceArrows[0] = forceArrows[1];
            forceArrows[1] = temp;
            x = 0;
            ChangeDirection();
        }

        time += Time.deltaTime;
        if (time > interval)
        {
            if (num_particles < maxParticles)
            {
                particlesList.Add(Instantiate(particlePrefab, initialPos.position, Quaternion.identity));
                particlesList[num_particles].GetComponent<MeshRenderer>().enabled = false;
                particlesList[num_particles].transform.parent = rot;
                num_particles++;
            }
            else
            {
                PowerButton.SetActive(true);
                LoadingScreen.SetActive(false);
            }
            time = 0;
            switch (dots)
            {
                case 0:
                    loadingText.text = "Loading";
                    dots++;
                    break;
                case 1:
                    loadingText.text = "Loading.";
                    dots++;
                    break;
                case 2:
                    loadingText.text = "Loading..";
                    dots++;
                    break;
                case 3:
                    loadingText.text = "Loading...";
                    dots++;
                    break;
                default:
                    loadingText.text = "Loading";
                    dots = 1;
                    break;
            }
        }

        for (int i = 0; i < labels.Length; i++)
            labels[i].position = labelAnchors[i].position;
    }
    private void Rotate()
    {
        rot.Rotate(_rotation * _speed * Time.deltaTime);
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            //reverseButton.SetActive(false);
            foreach (GameObject particle in particlesList)
                particle.GetComponent<MeshRenderer>().enabled = true;
            foreach (Transform forceArrow in forceArrows)
                if (xx==1) forceArrow.gameObject.SetActive(true);
        }
        else
        {
            PowerToogleButton = false;
            //reverseButton.SetActive(true);
            foreach (GameObject particle in particlesList)
                particle.GetComponent<MeshRenderer>().enabled = false;
            foreach (Transform forceArrow in forceArrows)
                forceArrow.gameObject.SetActive(false);
        }
    }
    public void ChangeCurrent(float val)
    {
        _speed = val;
    }
    private void ChangeDirection()
    {
        foreach(GameObject particle in particlesList)
        {
            Current_Flow c = particle.GetComponent<Current_Flow>();
            c.wayPointList.Reverse();
            c.currentWayPoint = c.wayPointList.Count - c.currentWayPoint;
        }
    }
    public void ShowLabels()
    {
        if(xx==0)
        {
            foreach (Transform label in labels)
                label.gameObject.SetActive(true);
            foreach (Transform forceArrow in forceArrows)
                if(PowerToogleButton) forceArrow.gameObject.SetActive(true);
            xx = 1;
        }
        else
        {
            foreach (Transform label in labels)
                label.gameObject.SetActive(false);
            foreach (Transform forceArrow in forceArrows)
                forceArrow.gameObject.SetActive(false);
            xx = 0;
        }
    }
}
