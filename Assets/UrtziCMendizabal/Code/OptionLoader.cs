using System;
using UnityEngine;

public class OptionLoader : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private GameObject singleSwordPrefab;
    [SerializeField]
    private GameObject multiSwordPrefab;
    [SerializeField]
    private GameObject bowPrefab;

    private void Start()
    {
        SpawnWeapon(PlayerPrefs.GetInt("weapon", 0));

        gm.scoreToEnd = PlayerPrefs.GetInt("targetScore", 10);

        gm.mode = PlayerPrefs.GetInt("mode");

    }



    private void SpawnWeapon(int v)
    {
        switch (v)
        {
            case 0:
                Instantiate(singleSwordPrefab);
                break;
            case 1:
                Instantiate(multiSwordPrefab);
                break;
            case 2:
                Instantiate(bowPrefab);
                break;

        }
    }
}
