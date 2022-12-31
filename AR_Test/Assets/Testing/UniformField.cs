using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class UniformField : MonoBehaviour
{
    [SerializeField] Vector3 magneticField = new Vector3(0f, 1f, 0f);
    Rigidbody rb;
    [SerializeField] Vector3 vel_i = new Vector3(1f, 0f, 0f);
    [SerializeField] float charge = 1f;
    LineRenderer lr;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = vel_i;
    }
    private void FixedUpdate()
    {
        Vector3 magneticForce = charge * Vector3.Cross(rb.velocity, magneticField);
        rb.AddForce(magneticForce, ForceMode.Force);
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, transform.position);
    }
}
