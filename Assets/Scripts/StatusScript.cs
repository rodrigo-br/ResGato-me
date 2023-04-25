using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusScript : MonoBehaviour
{
    TextMeshProUGUI statusText;
    SliderGroup mySliderGroup;

    void Awake()
    {
        statusText = GetComponent<TextMeshProUGUI>();
        mySliderGroup = FindObjectOfType<SliderGroup>();
    }

    void Start()
    {
        UpdateStatusText();
    }

    void OnEnable()
    {
        mySliderGroup.OnAtributesChange += UpdateStatusText;
    }

    void OnDisable()
    {
        mySliderGroup.OnAtributesChange += UpdateStatusText;
    }

    void UpdateStatusText()
    {
        statusText.text = "\t\t\tFood\t\tWater\nmaxValue:\t\t"
        + mySliderGroup.maxValue[0] + "\t\t" + mySliderGroup.maxValue[1]
        + "\ncurrentValue:\t"
        + mySliderGroup.currentValue[0] + "\t\t" + mySliderGroup.currentValue[1]
        + "\ntimeBetweenTick:\t"
        + mySliderGroup.decreaseSpeed[0].ToString("N1") + "\t\t" + mySliderGroup.decreaseSpeed[1].ToString("N1")
        + "\ntickValue:\t\t"
        + mySliderGroup.decreaseAmount[0] + "\t\t" + mySliderGroup.decreaseAmount[1];
    }
}
