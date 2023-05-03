using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BreakInfinity;

public class PlayerStatus : MonoBehaviour
{
    public delegate void CatChangeEvent();
    public event CatChangeEvent OnCatChangeEvent;
    public delegate void CoinChangeEvent();
    public event CatChangeEvent OnCoinChangeEvent;
    public delegate void EarnCoinChangeEvent();
    public event EarnCoinChangeEvent OnEarCoinChangeEvent;
    BigDouble catAmount = 0;
    BigDouble coinAmount = 0;
    BigDouble earnCoinAmount = 1;

    void Start()
    {
        OnCoinChangeEvent();
        OnCatChangeEvent();
        OnEarCoinChangeEvent();
    }

    void ChangeCatAmount(BigDouble value)
    {
        catAmount += value;
        OnCatChangeEvent();
    }

    void ChangeCoinAmount(BigDouble value)
    {
        coinAmount += value;
        OnCoinChangeEvent();
    }

    public void PowerEarnings(BigDouble value)
    {
        earnCoinAmount += value;
        OnEarCoinChangeEvent();
    }

    public void BuySomething(BigDouble value) => ChangeCoinAmount(-value);

    public void EarnCoinOnClick() => ChangeCoinAmount(earnCoinAmount);

    public BigDouble GetCoinAmount() => coinAmount;

    public BigDouble GetCatAmount() => catAmount;

    public BigDouble GetEarnCoinAmount() => earnCoinAmount;
}
