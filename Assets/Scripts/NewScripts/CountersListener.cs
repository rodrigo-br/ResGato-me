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
            myPlayerStatus.OnCatChangeEvent.AddListener(OnUpdateText);
        }
        else if (isListeningTo == IsListeningTo.CoinAmount)
        {
            format = "F2";
            myPlayerStatus.OnCoinChangeEvent.AddListener(OnUpdateText);
        }
    }

    void OnUpdateText(BigDouble value)
    {
        myText.text = $"{value.ToString(format)}";
    }
}
