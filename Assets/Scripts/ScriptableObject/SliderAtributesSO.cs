using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSliderAtributeSO", menuName = "SliderAtribute")]
public class SliderAtributesSO : ScriptableObject
{
    public string sliderName;
    public int maxValue = 60;
    public int decreaseAmount = 0;
    public float decreaseSpeed = 1f;

}
