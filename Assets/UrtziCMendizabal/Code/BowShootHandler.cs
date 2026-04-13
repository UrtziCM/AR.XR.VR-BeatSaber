using System;
using UnityEngine;

public class BowShootHandler : MonoBehaviour
{
    [SerializeField]
    Transform bowStringTransform;
    private Quaternion bowStringInitialRotation;
    private Vector3 bowStringInitialPosition;

    [SerializeField]
    private GameObject bladePrefab;
    [SerializeField]
    private float shootForce = 1000;

    void Start()
    {
        bowStringInitialPosition = bowStringTransform.transform.position - transform.position;
    }

    void Update()
    {
        
    }

    public void ResetStringPosition()
    {
        Shoot();
        bowStringTransform.position = (transform.position + transform.rotation * bowStringInitialPosition);
    }

    private void Shoot()
    {
        Vector3 shootDirection = (transform.position - bowStringTransform.position).normalized;
        GameObject arrow = Instantiate(bladePrefab, transform.position, Quaternion.LookRotation(shootDirection, transform.up));
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.AddForce(shootDirection * shootForce, ForceMode.Acceleration);
    }

}
