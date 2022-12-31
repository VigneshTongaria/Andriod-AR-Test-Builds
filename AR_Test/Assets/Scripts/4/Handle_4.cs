using UnityEngine;
using Lean.Transition;

public class Handle_4 : MonoBehaviour
{
    public Transform needle;
    public Vector3[] rotations;
    public Transform[] clips;
    public GameObject reverseButton;
    bool PowerToogleButton;
    int index;
    private void Start()
    {
        index = 0;
    }

    public void RotateNeedle()
    {
        if (!PowerToogleButton)
        {
            PowerToogleButton = true;
            needle.localRotationTransition(Quaternion.Euler(rotations[index]), 1.0f);
            reverseButton.SetActive(false);
        }
        else
        {
            PowerToogleButton = false;
            needle.localRotationTransition(Quaternion.Euler(rotations[2]), 1.0f);
            reverseButton.SetActive(true);
        }
    }
    public void ToggleIndex()
    {
        index = 1 - index;
        Vector3 temp = clips[0].position;
        clips[0].position = clips[1].position;
        clips[1].position = temp;
    }
}