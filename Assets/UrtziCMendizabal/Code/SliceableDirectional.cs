using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent (typeof(Rigidbody))]
public class SliceableDirectional : Sliceable
{
    public Vector3 cutDirection;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        particles = GetComponent<ParticleSystem>();

        TMP_Text textMesh = GetComponentInChildren<TMP_Text>();
        switch (Random.Range(0,4))
        {
            case 0:
                cutDirection = Vector3.up;
                textMesh.text = "↑";
                break;
            case 1:
                cutDirection = Vector3.down;
                textMesh.text = "↓";
                break;
            case 2:
                cutDirection = Vector3.left;
                textMesh.text = "←";
                break;
            case 3:
                cutDirection = Vector3.right;
                textMesh.text = "→";
                break;

        }
    }
}
