using UnityEngine;
using UnityEngine.SceneManagement;

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
    private GameObject bombSliceablePrefab;
    [SerializeField]
    private GameObject directionalSliceablePrefab;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float bombProbability = .8f;
    // END Spawning 
    [Header("Scoring options")]
    // START Scoring
    [SerializeField]
    public int scoreToEnd;
    public int mode;

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
            SceneManager.LoadScene("MenuScene");
        }
    }

    private void SpawnSliceable()
    {
        GameObject sliceableGameObject = null;
        switch (mode)
        {
            case 0:
                sliceableGameObject = Instantiate(sliceablePrefab);
                break;
            case 1:
                if (Random.value > bombProbability)
                {
                    sliceableGameObject = Instantiate(bombSliceablePrefab);
                }
                else
                {
                    Instantiate(sliceablePrefab);
                }
                break;
            case 2:
                Instantiate(directionalSliceablePrefab);
                break;
        }
        Sliceable sliceableComponent = sliceableGameObject?.GetComponent<Sliceable>();
        Vector3 desiredPosition = (new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * distance)
            + new Vector3(0, Camera.main.transform.position.y); // Add camera height to position to keep at eye level
        sliceableGameObject.transform.position = Quaternion.AngleAxis(Random.Range(-15, 15), Vector3.up) * desiredPosition;

        sliceableComponent.direction = (Camera.main.transform.position - desiredPosition).normalized;
    }
}
