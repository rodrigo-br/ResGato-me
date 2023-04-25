using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    [SerializeField] ButtonsManager buttons;
    TextMeshProUGUI myMoneyText;
    MoneyCounter moneyCounter;

    void Awake()
    {
        myMoneyText = GetComponent<TextMeshProUGUI>();
        moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    void Start()
    {
        MoneyChangeListener();
    }

    void OnEnable()
    {
        moneyCounter.OnMoneyChange += MoneyChangeListener;
    }

    void OnDisable()
    {
        moneyCounter.OnMoneyChange += MoneyChangeListener;
    }

    void MoneyChangeListener()
    {
        myMoneyText.text = "$" + (moneyCounter.MoneyAmount).ToString();
    }
}
