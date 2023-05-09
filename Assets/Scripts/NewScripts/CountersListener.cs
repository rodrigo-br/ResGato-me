using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using TMPro;

public class CountersListener : MonoBehaviour
{
    enum IsListeningTo
    {
        CatAmount,
        CoinAmount,
        ClickPower
    }
    [SerializeField] IsListeningTo isListeningTo;
    TextMeshProUGUI myText;
    PlayerStatus myPlayerStatus;

    void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        myPlayerStatus = FindObjectOfType<PlayerStatus>();
    }

    void OnEnable()
    {
        if (isListeningTo == IsListeningTo.CatAmount)
        {
            myPlayerStatus.OnCatChangeEvent += OnUpdateText;
        }
        else if (isListeningTo == IsListeningTo.CoinAmount)
        {
            myPlayerStatus.OnCoinChangeEvent += OnUpdateText;
        }
        else if (isListeningTo == IsListeningTo.ClickPower)
        {
            myPlayerStatus.OnEarCoinChangeEvent += OnUpdateText;
        }
    }

    void OnDisable()
    {
        if (isListeningTo == IsListeningTo.CatAmount)
        {
            myPlayerStatus.OnCatChangeEvent -= OnUpdateText;
        }
        else if (isListeningTo == IsListeningTo.CoinAmount)
        {
            myPlayerStatus.OnCoinChangeEvent -= OnUpdateText;
        }
        else if (isListeningTo == IsListeningTo.ClickPower)
        {
            myPlayerStatus.OnEarCoinChangeEvent -= OnUpdateText;
        }
    }

    void OnUpdateText()
    {
        if (isListeningTo == IsListeningTo.CatAmount)
        {
            myText.text = $"{myPlayerStatus.catAmount.Notate()}";
        }
        else if (isListeningTo == IsListeningTo.CoinAmount)
        {
            myText.text = $"{myPlayerStatus.GetCoinAmount().Notate()}";
        }
        else if (isListeningTo == IsListeningTo.ClickPower)
        {
            myText.text = $"Click Power\n+ ${myPlayerStatus.GetEarnCoinAmount().Notate()} \n+ {myPlayerStatus.GetProductionCoinAmount().Notate()} /sec";
        }
    }
}
