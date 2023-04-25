using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BreakInfinity;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinAmountText;
    [SerializeField] TextMeshProUGUI catAmountText;
    BigDouble catAmount = 0;
    BigDouble coinAmount = 0;
    BigDouble earnCoinAmount = 1;

    void Start()
    {
        UpdateCountersText();
    }

    void UpdateCountersText()
    {
        coinAmountText.text = coinAmount.ToString();
        catAmountText.text = catAmount.ToString();
    }

    void ChangeCatAmount(BigDouble value)
    {
        catAmount += value;
        UpdateCountersText();
    }

    void ChangeCoinAmount(BigDouble value)
    {
        coinAmount += value;
        UpdateCountersText();
    }

    public void EarnCoinOnClick() => ChangeCoinAmount(earnCoinAmount);
}
