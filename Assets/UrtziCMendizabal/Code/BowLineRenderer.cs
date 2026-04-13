using UnityEngine;

public class BowLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform[] transforms;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transforms.Length; ++i)
        {
            lineRenderer.SetPosition(i, transforms[i].position);
        }
    }
    private void OnDrawGizmos()
    {
        lineRenderer = GetComponent<LineRenderer>();
        for (int i = 0; i < transforms.Length; ++i)
        {
            lineRenderer.SetPosition(i, transforms[i].position);
        }
    }
}
