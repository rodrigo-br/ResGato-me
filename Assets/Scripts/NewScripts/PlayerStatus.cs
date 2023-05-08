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
    public BigDouble catAmount {get; private set; } = 0;
    BigDouble coinAmount = 0;
    BigDouble earnCoinAmount = 1;
    BigDouble productionCoinAmount = 0;

    void Start()
    {
        OnCoinChangeEvent();
        OnCatChangeEvent();
        OnEarCoinChangeEvent();
        StartCoroutine(ProduceCoinCoroutine());
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            ChangeCatAmount(1);
        }
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

    public void PowerEarnings(BigDouble value, bool isProduction)
    {
        if (!isProduction)
        {
            earnCoinAmount += value;
        }
        else
        {
            productionCoinAmount += value;
        }
        OnEarCoinChangeEvent();
    }

    public void BuySomething(BigDouble value) => ChangeCoinAmount(-value);

    public void EarnCoinOnClick() => ChangeCoinAmount(earnCoinAmount);

    public void EarnCat(double amount) => ChangeCatAmount(amount);

    public BigDouble GetCoinAmount() => coinAmount;

    public BigDouble GetEarnCoinAmount() => earnCoinAmount;

    public BigDouble GetProductionCoinAmount() => productionCoinAmount;

    IEnumerator ProduceCoinCoroutine()
    {
        while (true)
        {
            coinAmount += productionCoinAmount;
            OnCoinChangeEvent();
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
