using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    float timeCounter = 0;
    public Transform oscillator;
    [SerializeField] float speed;
    [SerializeField] float width;
    [SerializeField] float height;
    Vector3 initialPosition;
    public bool canOscillate = false;
    public Animator[] anim;
    public GameObject[] litmusPaper;
    public GameObject[] objs;
    public GameObject nextButton;
    public AHandle_1 ah;
    public SoundA1 src;
    bool play = false;
    public Bottle bot;
    void Start()
    {
        initialPosition = oscillator.position;
    }

    void Update()
    {
        if(canOscillate) Oscillate();
    }
    void Oscillate()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * width;
        float y = 0;
        float z = Mathf.Sin(timeCounter) * height;
        Vector3 pos = new Vector3(initialPosition.x + x, initialPosition.y + y, initialPosition.z + z);
        oscillator.position = pos;
        if (timeCounter > 25)
        {
            anim[0].enabled = true;
            anim[0].SetBool("PlaceStirrer", false);
            canOscillate = false;
        }
    }
    public void FlipOscillate()
    {
        anim[0].enabled = false;
        timeCounter = 0;
        initialPosition = oscillator.position;
        canOscillate = !canOscillate;
    }
    public void OffAnimator()
    {
        anim[0].enabled = false;
    }
    public void ShowObjs()
    {
        foreach (GameObject obj in objs)
            obj.SetActive(true);
        ah.ChangeText(1);
        nextButton.SetActive(true);
    }
    public void RemoveObjs()
    {
        foreach (GameObject obj in objs)
            obj.SetActive(false);
        nextButton.SetActive(false);
        anim[0].SetTrigger("Restart");
        anim[1].SetTrigger("Restart");
        bot.y[0] = true;
        bot.y[3] = true;
        foreach (GameObject litmus in litmusPaper) litmus.transform.localScale = new Vector3(litmus.transform.localScale.x, 0f, litmus.transform.localScale.z);
    }
    public void PlayStir()
    {
        play = !play;
        src.PlayClip(1, play, true);
    }
}
