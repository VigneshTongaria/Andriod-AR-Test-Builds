using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundA1 : MonoBehaviour
{
    public AudioSource src;
    public AudioClip[] clips;
    public void PlayClip(int x, bool play, bool loop)
    {
        if (play)
        {
            src.clip = clips[x];
            src.Play();
        }
        if(clips[x].name == src.clip.name)
        {
            if (!play) src.Stop();
            src.loop = loop;
        }
    }
}
