using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMHandle1 : MonoBehaviour
{
    public Animator flaskAnim;
    public void Suspend()
    {
        flaskAnim.SetTrigger("Suspend");
    }
    public void React()
    {
        flaskAnim.SetTrigger("React");
    }
}
