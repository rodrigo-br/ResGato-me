using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGroup : Singleton<SliderGroup>
{
    public int[] maxValue;
    public int[] currentValue;
    public int[] decreaseAmount;
    public float[] decreaseSpeed;
    protected override void Awake()
    {
        base.Awake();
    }
}
