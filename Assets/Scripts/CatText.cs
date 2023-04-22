using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatText : MonoBehaviour
{
    TextMeshProUGUI myCatText;
    CatCounter catCounter;

    void Awake()
    {
        myCatText = GetComponent<TextMeshProUGUI>();
        catCounter = FindObjectOfType<CatCounter>();
    }

    void Start()
    {
        CatChangeListener();
    }

    void OnEnable()
    {
        catCounter.OnCatChange += CatChangeListener;
    }

    void OnDisable()
    {
        catCounter.OnCatChange += CatChangeListener;
    }

    void CatChangeListener()
    {
        myCatText.text = (catCounter.CatAmount).ToString();
    }
}
