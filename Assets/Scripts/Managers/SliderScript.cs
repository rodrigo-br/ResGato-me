using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : Singleton<SliderScript>
{
    [SerializeField] SliderAtributesSO sliderAtributes;
    Slider slider;
    bool isDecreasing = true;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        Slider[] sliders = FindObjectsOfType<Slider>();
        foreach (Slider sliderFound in sliders)
        {
            if (sliderFound.tag == sliderAtributes.sliderName)
            {
                slider = sliderFound;
            }
        }
        slider.value = sliderAtributes.maxValue;
        StartCoroutine(DecreaseSliderValueCoroutine());
    }

    IEnumerator DecreaseSliderValueCoroutine()
    {
        while (isDecreasing)
        {
            yield return new WaitForSecondsRealtime(sliderAtributes.decreaseSpeed);
            ChangeSliderValue(-sliderAtributes.decreaseAmount);
        }
    }

    void ChangeSliderValue(int value)
    {
        slider.value += value;
    }

    public void ChangeDecreaseAmount(int value)
    {
        sliderAtributes.decreaseAmount += value;
    }
}

