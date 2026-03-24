using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Spawning options")]
    // START Spawning 
    [SerializeField, Range(0.1f, 25)]
    private float timeInbetweenSpawns;
    private float accumulatedTime;
    [SerializeField]
    private GameObject sliceablePrefab;
    [SerializeField]
    private float distance;
    // END Spawning 
    [Header("Scoring options")]
    // START Scoring
    [SerializeField]
    private int scoreToEnd;
    public bool ShouldGameEnd => ScoreManager.Score >= scoreToEnd;
    // END Scoring

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > timeInbetweenSpawns)
        {
            accumulatedTime = 0;
            SpawnSliceable();
        }

        if (ShouldGameEnd)
        {
            Debug.Log("Game end");
            Application.Quit();
        }
    }

    private void SpawnSliceable()
    {
        GameObject sliceableGameObject = Instantiate(sliceablePrefab);
        Sliceable sliceableComponent = sliceableGameObject.GetComponent<Sliceable>();

        Vector3 desiredPosition = (new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * distance)
            + new Vector3(0, Camera.main.transform.position.y); // Add camera height to position to keep at eye level
        sliceableGameObject.transform.position = Quaternion.AngleAxis(Random.Range(-30,30), Vector3.up) * desiredPosition;

        sliceableComponent.Direction = (Camera.main.transform.position - desiredPosition).normalized;
    }
}
