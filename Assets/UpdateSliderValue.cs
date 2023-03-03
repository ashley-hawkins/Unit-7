using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderValue : MonoBehaviour
{
    public Slider slider;
    public TMPro.TextMeshProUGUI textMeshPro;
    public string fieldName;
    public SoundInfo.SoundType soundType;
    // Start is called before the first frame update
    private void Awake()
    {
        slider.SetValueWithoutNotify(PlayerPrefs.GetFloat(soundType.ToString() + "Volume", 100f));
        Execute();
    }
    public void Execute()
    {
        textMeshPro.text = fieldName + ": " + ((slider.value == 0) ? "OFF" : slider.value + "%");
        PlayerPrefs.SetFloat(soundType.ToString() + "Volume", slider.value);
        SoundSystem.soundSystem.SetVolumeAll(soundType, slider.value / 100f);
    }
}
