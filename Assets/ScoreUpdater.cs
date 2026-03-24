using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private TMP_Text textMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        textMesh.text = "Score:" + ScoreManager.Score;
    }
}
