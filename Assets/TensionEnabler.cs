using UnityEngine;

public class TensionEnabler : MonoBehaviour
{

    [SerializeField]
    private GameObject tensionPickable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveTensor(bool active)
    {
        tensionPickable.SetActive(active);
    }
}
