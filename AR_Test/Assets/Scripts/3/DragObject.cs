using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Transition;
using Lean;
using Lean.Transition.Method;

public class DragObject : MonoBehaviour
{
    private float mZCoord;
    private float initialY;
    public Vector3 newPosition;

    public Transform spellEffect;
    public AudioSource[] src;
    public AudioClip[] clips;
    public float pitchOffset;
    public float initialPitch;

    [SerializeField] int currentIndex;
    public Transform[] wayPoints;
    public float snapValue = 0.1f;
    private Vector3 mOffset;
    private bool playSound = true;

    public float[] fillPoints;
    public Image[] fieldImage;
    private void Start()
    {
        initialY = transform.position.y;
        transform.position = wayPoints[0].position;
        currentIndex = 0;
        src[1].pitch = initialPitch;
    }
    private void Update()
    {
        if (currentIndex < wayPoints.Length && transform.position == wayPoints[currentIndex].position && !Input.GetKey(KeyCode.Mouse0))
        {
            LeanExtensions.fillAmountTransition(fieldImage[0], fillPoints[currentIndex], 1, LeanEase.Smooth);
            LeanExtensions.fillAmountTransition(fieldImage[1], fillPoints[currentIndex], 1, LeanEase.Smooth);
            src[1].clip = clips[1];
            src[1].pitch += pitchOffset;
            if(currentIndex!=0) src[1].Play();
            currentIndex++;
            if (currentIndex == wayPoints.Length) Destroy(spellEffect.gameObject);
            else spellEffect.position = wayPoints[currentIndex].position;
        }
        if (currentIndex < wayPoints.Length && transform.position == wayPoints[currentIndex].position)
        {
            src[0].clip = clips[0];
            if (playSound)
            {
                src[0].Play();
                playSound = false;
            }
        }
        else playSound = true;
        if (currentIndex == wayPoints.Length)
        {
            src[0].clip = clips[1];
            src[0].Play();
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            currentIndex++;
        }
        if (!Input.GetKey(KeyCode.Mouse0) && currentIndex < wayPoints.Length && transform.position != wayPoints[currentIndex].position) transform.position = wayPoints[currentIndex - 1].position;
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorlPos();
    }

    private Vector3 GetMouseWorlPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        newPosition = GetMouseWorlPos() + mOffset;
        newPosition = new Vector3(newPosition.x, initialY, newPosition.z);
        if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < snapValue) newPosition = wayPoints[currentIndex].position;
        transform.position = newPosition;
    }
}
