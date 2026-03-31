using UnityEngine;

public class OptionLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject leftSaber;
    [SerializeField] 
    private GameManager gm;

    private void Start()
    {
        if (PlayerPrefs.GetInt("doubleSaber") == 0)
            leftSaber.SetActive(false);

        gm.scoreToEnd = PlayerPrefs.GetInt("targetScore", 10);

        gm.hardMode = PlayerPrefs.GetInt("hardMode") == 1;

        Debug.Log("score:"+gm.scoreToEnd);
    }

}
