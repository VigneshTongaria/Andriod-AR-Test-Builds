using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundObject : MonoBehaviour
{
    [SerializeField]
    Transform mainCam;
    [SerializeField]
    float movSpeed = 1f;
    [SerializeField]
    float _mouseSensivity = 3.0f;
    private float _rotationY;
    private float _rotationX;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _distanceFromTarget = 3.0f;
    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;
    [SerializeField]
    private float _smoothTime = 0.2f;
    float startTime;
    public BoxCollider boundary;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) Rotate();
        else if (Input.GetKey(KeyCode.Mouse1)) Translate();
        else startTime = 0;
    }
    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
            if (Input.GetMouseButton(0))
                return UnityEngine.Input.GetAxis("Mouse X");
            else
                return 0;
        else if (axisName == "Mouse Y")
            if (Input.GetMouseButton(0))
                return UnityEngine.Input.GetAxis("Mouse Y");
            else
                return 0;
        return UnityEngine.Input.GetAxis(axisName);
    }
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity;
        float mouseY = -Input.GetAxis("Mouse Y") * _mouseSensivity;
        _rotationX += mouseY;
        _rotationY += mouseX;
        _rotationX = Mathf.Clamp(_rotationX, -40, 40);
        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        _currentRotation = new Vector3(Mathf.Clamp(_currentRotation.x, 0f, 90f), _currentRotation.y, _currentRotation.z); //
        transform.localEulerAngles = _currentRotation;
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
    private void Translate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 projectx = Vector3.ProjectOnPlane(mainCam.right, Vector3.up).normalized * -mouseX;
        Vector3 projecty = Vector3.ProjectOnPlane(mainCam.forward, Vector3.up).normalized * -mouseY;
        Vector3 dir = (projectx + projecty).normalized * movSpeed / 40;

        float distCovered = (Time.time - startTime) * movSpeed;
        float journeyLength = (transform.position + dir).magnitude;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, transform.position + dir, Mathf.SmoothStep(0, 1, fractionOfJourney));

        distCovered = (Time.time - startTime) * movSpeed;
        journeyLength = (_target.position + dir).magnitude;
        fractionOfJourney = distCovered / journeyLength;
        _target.position = Vector3.Lerp(_target.position, _target.position + dir, Mathf.SmoothStep(0, 1, fractionOfJourney));
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, boundary.bounds.min.x, boundary.bounds.max.x),
        Mathf.Clamp(transform.position.y, boundary.bounds.min.y, boundary.bounds.max.y),
        Mathf.Clamp(transform.position.z, boundary.bounds.min.z, boundary.bounds.max.z));
    }
}
