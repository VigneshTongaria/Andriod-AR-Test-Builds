using UnityEngine;
using Lean.Transition;

public class Grabber : MonoBehaviour
{

    private GameObject selectedObject;
    public Transform bar_magnet;

    Light bulb;
    public Transform pointer;

    int x = 1;

    private float speed;
    private void Start()
    {
        bulb = GetComponent<Light>();
    }

    private void Update()
    {
        Drag();
        PowerControl();
    }

    private void Drag()
    {
        if (Input.GetMouseButton(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }
                    selectedObject = hit.collider.gameObject;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                Vector3 dir = new Vector3(worldPosition.x, selectedObject.transform.position.y, selectedObject.transform.position.z);
                speed = Input.GetAxis("Mouse X") * 50 * x;
                if (selectedObject.name == "Bar_Magnet")
                {
                    if (dir.x > -0.265f)
                    {
                        dir.x = -0.265f; speed = 0f;
                    }
                    if (dir.x < -3.55f)
                    {
                        dir.x = -3.55f; speed = 0f;
                    }
                }
                if (selectedObject.name == "Solenoid")
                {
                    if (dir.x < 0.105f)
                    {
                        dir.x = 0.105f; speed = 0f;
                    }
                    if (dir.x > 4.7f)
                    {
                        dir.x = 4.7f; speed = 0f;
                    }
                    speed *= -1f;
                }
                selectedObject.transform.position = dir;
            }
        }
        else
        {
            selectedObject = null;
            speed = 0f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bar_magnet.rotation = Quaternion.Euler(new Vector3(
                bar_magnet.rotation.eulerAngles.x,
                bar_magnet.rotation.eulerAngles.y + 180f,
                bar_magnet.rotation.eulerAngles.z));
            x *= -1;
        }
    }


    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    public void PowerControl()
    {
        Vector3 dir = new Vector3(-52.837f, 0f, speed);
        pointer.localRotationTransition(Quaternion.Euler(dir), Time.deltaTime*50f, LeanEase.Decelerate);
        bulb.intensityTransition(Mathf.Abs(speed) / 15f, Time.deltaTime * 10f, LeanEase.Smooth);
    }
}
