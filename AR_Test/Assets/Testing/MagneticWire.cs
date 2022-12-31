using UnityEngine;

public class MagneticWire : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Vector3 axisDirection = new Vector3(0f, 1f, 0f);
    [Header("Parameters")]
    [Tooltip("In SI Units")]
    float mu = 4f * 3.14f * 1e-7f;
    private float pie = 3.14f;
    [Range(0,10)] [Tooltip("In Amperes")]
    public float current = 1;
    [Tooltip("In Coulombs")]
    [SerializeField] float charge = 1; //for now lets assume
    [SerializeField] Vector3 vel_i;
    LineRenderer lr;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        foreach (GameObject obj in gameObjects)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.velocity = vel_i;
        }
    }
    private void Update()
    {
        foreach(GameObject obj in gameObjects)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            Vector3 vel = rb.velocity;
            Vector3 dis = obj.transform.position - transform.position;
            Vector3 r = Vector3.ProjectOnPlane(dis, axisDirection);
            Vector3 phi = Vector3.Cross(axisDirection, r).normalized;
            Vector3 magneticField = (mu * current / (2 * pie * r.magnitude)) * phi;
            Vector3 magneticForce = charge * Vector3.Cross(vel, magneticField);
            rb.AddForce(magneticForce);
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, obj.transform.position);
        }
    }
}
