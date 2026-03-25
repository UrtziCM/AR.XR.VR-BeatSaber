using UnityEngine;
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
        doubleSaber = PlayerPrefs.GetInt("doubleSaber") == 1;
        targetScore = PlayerPrefs.GetInt("targetScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaberToggleChanged()
    {
        doubleSaber = DoubleSaberToggle.isOn;
        DoubleSaberToggleText.text = (DoubleSaberToggle.isOn)?"Dos sables":"Un sable";

    }

    public void TargetScoreSliderChanged()
    {
        sliderText.text = targetScoreSlider.value+"";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("doubleSaber", doubleSaber?1:0);
        PlayerPrefs.SetInt("targetScore", targetScore);
        PlayerPrefs.Save();
    }
}
