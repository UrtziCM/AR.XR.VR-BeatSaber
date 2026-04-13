using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionSaver : MonoBehaviour
{
    private int targetScore;



    [SerializeField]
    Slider targetScoreSlider;
    [SerializeField]
    Text sliderText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("weapon"))
            PlayerPrefs.SetInt("weapon", 0);
        if (!PlayerPrefs.HasKey("targetScore"))
            PlayerPrefs.SetInt("targetScore", 10);
        else
            targetScore = PlayerPrefs.GetInt("targetScore");

        if (!PlayerPrefs.HasKey("mode"))
            PlayerPrefs.SetInt("mode", 0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaberDropdownChanged(Int32 value)
    {
        PlayerPrefs.SetInt("weapon", value);

    }

    public void TargetScoreSliderChanged()
    {
        sliderText.text = targetScoreSlider.value.ToString();
        PlayerPrefs.SetInt("targetScore", (int)targetScoreSlider.value);
    }

    public void ChangeToPlayground(int mode = 0)
    {
        PlayerPrefs.SetInt("mode", mode);
        SceneManager.LoadScene("PlayingField");
    }
}
