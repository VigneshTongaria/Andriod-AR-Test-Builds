using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    Label[] labels;
    bool boolToogleButton;
    public bool PowerToogleButton;
    public TMP_Text powerText;
    public AudioSource src;
    [SerializeField]
    AudioClip[] clips;
    Coroutine bulb_sound_coroutine = null;
    void Start()
    {
        labels = FindObjectsOfType<Label>();
    }
    public void Labels()
    {
        if (!boolToogleButton)
        {
            boolToogleButton = true;
            ShowLabels();
        }
        else
        {
            boolToogleButton = false;
            HideLabels();
        }
    }
    private void ShowLabels()
    {
        labels = FindObjectsOfType<Label>(); // Remove this line if an issue occurs
        foreach (Label label in labels)
        {
            label.Show();
        }
    }
    private void HideLabels()
    {
        foreach (Label label in labels)
        {
            label.Hide();
        }
    }
    public void Home()
    {
        Application.OpenURL("https://github.com/AbhishekPardhi");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TogglePower()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            powerText.text = "Off";
            if (clips.Length < 3)
            {
                Debug.Log("Please attach 3 clips in the inspector window");
                return;
            }
            bulb_sound_coroutine = StartCoroutine(PlaySound());
        }
        else
        {
            PowerToogleButton = false;
            powerText.text = "On";
            if (clips.Length < 3)
            {
                Debug.Log("Please attach 3 clips in the inspector window");
                return;
            }
            StopPlaying();
        }
    }
    IEnumerator PlaySound()
    {
        src.clip = clips[0];
        src.Play();
        yield return new WaitForSeconds(clips[0].length);
        src.clip = clips[1];
        src.Play();
        src.loop = true;
    }
    public void StopPlaying()
    {
        if(bulb_sound_coroutine!=null) StopCoroutine(bulb_sound_coroutine);
        src.clip = clips[2];
        src.Play();
        src.loop = false;
    }
}
