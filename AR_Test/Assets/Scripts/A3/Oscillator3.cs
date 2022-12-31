using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator3 : MonoBehaviour
{
    public Transform oscillator;
    float timeCounter = 0;
    [SerializeField] float speed;
    [SerializeField] float width;
    [SerializeField] float height;
    Vector3 initialPosition;
    public bool canOscillate = false;
    public Animator[] anim;
    public SoundA1 src;
    bool play = false;
    public GameObject nextButton;
    public AHandle_3 ah;
    public AudioSource altsrc;
    void Start()
    {
        initialPosition = oscillator.position;
    }
    void Update()
    {
        if (canOscillate) Oscillate();
    }
    void Oscillate()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * width;
        float y = 0;
        float z = Mathf.Sin(timeCounter) * height;
        Vector3 pos = new Vector3(initialPosition.x + x, initialPosition.y + y, initialPosition.z + z);
        oscillator.position = pos;
        if (timeCounter > 25f)
        {
            anim[0].enabled = true;
            anim[0].SetBool("PlaceStirrer", false);
            canOscillate = false;
        }
        if(ah.flag)
        {
            ah.AddIndicator();
            ah.flag = false;
        }
    }
    public void FlipOscillate()
    {
        anim[0].enabled = false;
        timeCounter = 0;
        initialPosition = oscillator.position;
        canOscillate = !canOscillate;
    }
    public void PlayStir()
    {
        play = !play;
        if (play) altsrc.Play();
        else altsrc.Stop();
    }
    public void ShowObjs()
    {
        nextButton.SetActive(true);
    }
}
