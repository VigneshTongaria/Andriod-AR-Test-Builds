using UnityEngine;
using Lean.Transition;

public class Handle_11 : MonoBehaviour
{
    bool PowerToogleButton;
    Light bulb;
    public Transform plug;
    public Vector3[] plug_pos;
    public Vector3[] plug_rot;
    public Transform pointer;
    Vector3 dir = new Vector3(-52.837f, 0f, 30f);
    public AudioSource src;
    public AudioClip clip;
    private void Start()
    {
        bulb = GetComponent<Light>();
    }
    public void PowerControl()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            plug.position = plug_pos[0];
            plug.rotation = Quaternion.Euler(plug_rot[0]);
            dir.z = -30f;
        }
        else
        {
            PowerToogleButton = false;
            plug.position = plug_pos[1];
            plug.rotation = Quaternion.Euler(plug_rot[1]);
            dir.z = 30f;
        }
        src.Play();
        src.SetScheduledEndTime(AudioSettings.dspTime + 0.5f);
        bulb.intensityTransition(1f, 0.5f, LeanEase.Smooth);
        bulb.JoinDelayTransition<Light>(0.1f);
        bulb.intensityTransition(0f, 0.5f, LeanEase.Smooth);
        pointer.localRotationTransition(Quaternion.Euler(dir), 0.5f, LeanEase.Elastic);
        dir.z = 0f;
        pointer.JoinDelayTransition<Transform>(0.1f);
        pointer.localRotationTransition(Quaternion.Euler(dir), 0.5f, LeanEase.Elastic);
    }
}
