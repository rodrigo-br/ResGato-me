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
        CoinAmount
    }
    [SerializeField] IsListeningTo isListeningTo;
    TextMeshProUGUI myText;
    PlayerStatus myPlayerStatus;
    string format;

    void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        myPlayerStatus = FindObjectOfType<PlayerStatus>();
    }

    void OnEnable()
    {
        if (isListeningTo == IsListeningTo.CatAmount)
        {
            format = null;
            myPlayerStatus.OnCatChangeEvent += OnUpdateText;
        }
        else if (isListeningTo == IsListeningTo.CoinAmount)
        {
            format = "F2";
            myPlayerStatus.OnCoinChangeEvent += OnUpdateText;
        }
    }

    void OnUpdateText()
    {
        if (isListeningTo == IsListeningTo.CatAmount)
        {
            myText.text = $"{myPlayerStatus.GetCatAmount().ToString(format)}";
        }
        else if (isListeningTo == IsListeningTo.CoinAmount)
        {
            myText.text = $"{myPlayerStatus.GetCoinAmount().ToString(format)}";
        }
    }
}
