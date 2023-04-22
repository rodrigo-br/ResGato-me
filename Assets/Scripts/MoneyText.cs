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
        buttons.OnMoneyChange += MoneyChangeListener;
    }

    void OnDisable()
    {
        buttons.OnMoneyChange += MoneyChangeListener;
    }

    void MoneyChangeListener()
    {
        myMoneyText.text = "$" + (moneyCounter.MoneyAmount).ToString();
    }
}
