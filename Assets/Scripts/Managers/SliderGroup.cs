using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGroupValues
{
    public int[] maxValue;
    public int[] currentValue;
    public int[] decreaseAmount;
    public float[] decreaseSpeed;
    public SliderGroupValues(int[] _maxValue, int[] _currentValue, int[] _decreaseAmount, float[] _decreaseSpeed)
    {
        this.maxValue = _maxValue;
        this.currentValue = _currentValue;
        this.decreaseAmount = _decreaseAmount;
        this.decreaseSpeed = _decreaseSpeed;
    }
}

public class SliderGroup : Singleton<SliderGroup>
{
    public delegate void AtributesChange();
    public event AtributesChange OnAtributesChange;
    public int[] maxValue;
    public int[] currentValue;
    public int[] decreaseAmount;
    public float[] decreaseSpeed;

    public SliderGroupValues ReturnClass()
    {
        return new SliderGroupValues(maxValue, currentValue, decreaseAmount, decreaseSpeed);
    }

    public void SetSliderGroup(SliderGroupValues sliderGroupValues)
    {
        this.maxValue = sliderGroupValues.maxValue;
        this.currentValue = sliderGroupValues.currentValue;
        this.decreaseAmount = sliderGroupValues.decreaseAmount;
        this.decreaseSpeed = sliderGroupValues.decreaseSpeed;
        OnAtributesChange();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public void UpdateAtributes(int index, int deltaMaxFixo,  int deltaConsumoFixo, float deltaDecreaseSpeedFixo,
                        float deltaMaxPerc, float deltaConsumoPerc, float deltaDecreaseSpeedPerc)
    {
        maxValue[index] += deltaMaxFixo;
        currentValue[index] += deltaConsumoFixo;
        decreaseSpeed[index] += deltaDecreaseSpeedFixo;
        maxValue[index] += Mathf.CeilToInt(deltaMaxPerc * maxValue[index] / 100);
        currentValue[index] += Mathf.CeilToInt(deltaConsumoPerc * maxValue[index] / 100);
        decreaseSpeed[index] += (deltaDecreaseSpeedPerc * decreaseSpeed[index] / 100);
        currentValue[index] = Mathf.Clamp(currentValue[index], 0, maxValue[index]);
        decreaseSpeed[index] = Mathf.Clamp(decreaseSpeed[index], 0.1f, float.MaxValue);
        OnAtributesChange();
    }
}
