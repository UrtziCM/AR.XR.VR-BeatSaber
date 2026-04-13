using Unity.VisualScripting;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField]
    private Color saberColor;

    private Vector3 lastFramePosition;
    private Vector3 deltaPos;

    private void OnValidate()
    {
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = saberColor;
        lastFramePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = transform.position - lastFramePosition;
        lastFramePosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sliceable"))
        {

            Sliceable sl = other.gameObject.GetComponent<SliceableDirectional>();
            if (sl == null)
            {
                sl = other.gameObject.GetComponent<Sliceable>();
                StartCoroutine(sl.Slice());
                ScoreManager.AddScore(sl.score);
            }
            else if (Vector3.Dot(lastFramePosition, (sl as SliceableDirectional).cutDirection) <  .75)  {
                StartCoroutine(sl.Slice());
                ScoreManager.AddScore(sl.score);
            }

        }
    }
}
