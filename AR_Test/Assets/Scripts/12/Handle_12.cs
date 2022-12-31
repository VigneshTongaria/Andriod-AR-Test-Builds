using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Handle_12 : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    public Transform rot;
    bool PowerToogleButton;
    float tempRot;

    public Transform[] forceArrows;
    public Transform[] forceArrowsAnchor;

    public Vector3[] forceArrowsRot;

    public RectTransform[] labels;
    public Transform[] labelAnchors;
    private int xx = 0;

    public Transform pointer;
    Vector3 dir = new Vector3(-52.837f, 0f, 30f);

    public AudioSource src;

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
            Rotate();
        else
        {
            PowerToogleButton = false;
            foreach (Transform forceArrow in forceArrows)
                forceArrow.gameObject.SetActive(false);
            dir.z = 0f;
            pointer.localRotationTransition(Quaternion.Euler(dir), 0.5f, LeanEase.Elastic);
            src.Pause();
        }
        tempRot = rot.localRotation.eulerAngles.x;
        for (int i = 0; i < labels.Length; i++)
            labels[i].position = labelAnchors[i].position;
        forceArrows[0].position = forceArrowsAnchor[0].position;
        forceArrows[1].position = forceArrowsAnchor[1].position;
    }
    private void Rotate()
    {
        rot.Rotate(_rotation * _speed * Time.deltaTime);
        PowerToogleButton = true;
        foreach (Transform forceArrow in forceArrows)
                forceArrow.gameObject.SetActive(true);
        if (tempRot > 270f)
        {
            dir.z = 30f;
            RotateArrow(0);
        }
        else
        {
            dir.z = -30f;
            RotateArrow(1);
        }
        pointer.localRotationTransition(Quaternion.Euler(dir), Time.deltaTime * 100f, LeanEase.Elastic);
        if(!src.isPlaying) src.Play();
    }
    public void ChangeSpeed(float val)
    {
        _speed = val;
    }
    private void RotateArrow(int id)
    {
        forceArrows[0].localRotation = Quaternion.Euler(forceArrowsRot[id]);
        forceArrows[1].localRotation = Quaternion.Euler(forceArrowsRot[id]);
    }
    public void ShowLabels()
    {
        if (xx == 0)
        {
            foreach (Transform label in labels)
                label.gameObject.SetActive(true);
            foreach (Transform forceArrow in forceArrows)
                if (PowerToogleButton) forceArrow.gameObject.SetActive(true);
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
