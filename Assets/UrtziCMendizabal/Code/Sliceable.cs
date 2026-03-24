using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Sliceable : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeToLive;

    private Vector3 direction;
    public Vector3 Direction { get { return direction; } set { direction = value; } }


    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.MovePosition(transform.position + (speed * Time.deltaTime * direction));
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
