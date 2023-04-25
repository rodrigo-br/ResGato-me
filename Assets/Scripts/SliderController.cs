using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    SliderGroup sliderGroup;
    Slider mySlider;
    int index;

    void Awake()
    {
        sliderGroup = FindObjectOfType<SliderGroup>();
        mySlider = GetComponent<Slider>();
    }

    void Start()
    {
        switch (gameObject.tag)
        {
            case "Food":
                index = 0;
                break;
            case "Water":
                index = 1;
                break;
            default:
                index = 2;
                break;
        }
        UpdateSlider();
        StartCoroutine(DecreaseValueRoutine());
    }

    void OnEnable()
    {
        sliderGroup.OnAtributesChange += UpdateSlider;
    }

    void OnDisable()
    {
        sliderGroup.OnAtributesChange += UpdateSlider;
    }

    void UpdateSlider()
    {
        mySlider.maxValue = sliderGroup.maxValue[index];
        mySlider.value = sliderGroup.currentValue[index];
    }

    IEnumerator DecreaseValueRoutine()
    {
        yield return new WaitForSecondsRealtime(sliderGroup.decreaseSpeed[index]);
        while(true)
        {
            if (mySlider.value > 0)
            {
                mySlider.value -= sliderGroup.decreaseAmount[index];
                sliderGroup.currentValue[index] -= sliderGroup.decreaseAmount[index];
            }
            yield return new WaitForSecondsRealtime(sliderGroup.decreaseSpeed[index]);
        }
    }
}
