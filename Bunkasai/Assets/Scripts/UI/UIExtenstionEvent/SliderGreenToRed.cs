using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGreenToRed : MonoBehaviour
{
    Slider slider;
    Image sliderImage;
    void Start()
    {
        slider = GetComponent<Slider>();
        sliderImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderImage.color = Color.Lerp(Color.green, Color.red, 1f - slider.value);
    }
}
