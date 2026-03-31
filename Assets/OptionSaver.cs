using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionSaver : MonoBehaviour
{
    private bool doubleSaber;
    private int targetScore;



    [SerializeField]
    Toggle DoubleSaberToggle;
    [SerializeField]
    Text DoubleSaberToggleText;

    [SerializeField]
    Slider targetScoreSlider;
    [SerializeField]
    Text sliderText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("doubleSaber"))
            PlayerPrefs.SetInt("doubleSaber", 0);
        else
            doubleSaber = PlayerPrefs.GetInt("doubleSaber") > 0;

        if (!PlayerPrefs.HasKey("targetScore"))
            PlayerPrefs.SetInt("targetScore", 10);
        else
            targetScore = PlayerPrefs.GetInt("targetScore");

        if (!PlayerPrefs.HasKey("hardMode"))
            PlayerPrefs.SetInt("hardMode", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaberToggleChanged()
    {
        doubleSaber = DoubleSaberToggle.isOn;
        DoubleSaberToggleText.text = (DoubleSaberToggle.isOn)?"Dos sables":"Un sable";
        PlayerPrefs.SetInt("doubleSaber", doubleSaber ? 1 : 0);

    }

    public void TargetScoreSliderChanged()
    {
        sliderText.text = targetScoreSlider.value.ToString();
        PlayerPrefs.SetInt("targetScore", (int)targetScoreSlider.value);
    }

    public void ChangeToPlayground(bool hardMode = false)
    {
        PlayerPrefs.SetInt("hardMode", hardMode ? 1 : 0);
        SceneManager.LoadScene("PlayingField");
    }
}
