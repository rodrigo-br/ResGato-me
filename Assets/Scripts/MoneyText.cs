using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    TextMeshProUGUI myMoneyText;

    void Awake()
    {
        myMoneyText = GetComponent<TextMeshProUGUI>();
    }

    
}
