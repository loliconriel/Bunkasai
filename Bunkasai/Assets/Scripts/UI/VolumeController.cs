using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    Slider slider;
    private void Awake()
    {
        float value = 0f;

        slider = GetComponent<Slider>();
        audioMixer.GetFloat(transform.parent.name,out value);
        slider.value = value;
        textMeshProUGUI.text = (Mathf.InverseLerp(slider.minValue, slider.maxValue, value) * 100f).ToString("F0") + "%";
        slider.onValueChanged.AddListener(ChangeVolume);
    }
    void ChangeVolume(float value)
    {
        audioMixer.SetFloat(transform.parent.name, value);
        textMeshProUGUI.text = (Mathf.InverseLerp(slider.minValue, slider.maxValue, value) * 100f).ToString("F0") + "%";
    }
}
