using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;
    public static void AddScore(int score)
    {
        ScoreManager.score += score;
    }

    public static int Score { get { return score; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
