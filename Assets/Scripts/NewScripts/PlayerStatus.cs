using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BreakInfinity;

public class PlayerStatus : MonoBehaviour
{
    [HideInInspector] public UnityEvent<BigDouble> OnCatChangeEvent;
    [HideInInspector] public UnityEvent<BigDouble> OnCoinChangeEvent;
    BigDouble catAmount = 0;
    BigDouble coinAmount = 0;
    BigDouble earnCoinAmount = 1;

    void Start()
    {
        if (OnCatChangeEvent == null)
        {
            OnCatChangeEvent = new UnityEvent<BigDouble>();
        }
        if (OnCoinChangeEvent == null)
        {
            OnCoinChangeEvent = new UnityEvent<BigDouble>();
        }
        OnCatChangeEvent.Invoke(catAmount);
        OnCoinChangeEvent.Invoke(coinAmount);
    }

    void ChangeCatAmount(BigDouble value)
    {
        catAmount += value;
        OnCatChangeEvent.Invoke(catAmount);
    }

    void ChangeCoinAmount(BigDouble value)
    {
        coinAmount += value;
        OnCoinChangeEvent.Invoke(coinAmount);
    }

    public void PowerEarnings(BigDouble value) => earnCoinAmount += value;

    public void BuySomething(BigDouble value) => ChangeCoinAmount(-value);

    public void EarnCoinOnClick() => ChangeCoinAmount(earnCoinAmount);

    public BigDouble GetCoinAmount() => coinAmount;
}
