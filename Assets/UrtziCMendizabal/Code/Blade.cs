using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField]
    private Color saberColor;


    private void OnValidate()
    {
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = saberColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sliceable"))
        {
            Destroy(other.gameObject);
            ScoreManager.AddScore(1);
        }
    }
}
