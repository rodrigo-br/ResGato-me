using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using TMPro;

public class BigValueData : MonoBehaviour
{
    TextMeshProUGUI text;
    BigDouble value;

    BigValueData()
    {
        value = 1;
    }

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        value *= 100;
        Debug.Log(value);
        text.text = value.ToString("G1");
    }
}
