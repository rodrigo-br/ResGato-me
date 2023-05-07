using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyXToggleHandler : MonoBehaviour
{
    [SerializeField] Color selectedColor;
    Toggle  myToggle;
    Image   myImage;   
    void Awake()
    {
        myToggle = GetComponent<Toggle>();
        myImage = GetComponentInChildren<Image>();
    }

    void Start()
    {
        if (myToggle.isOn)
        {
            myImage.color = selectedColor;
        }
        myToggle.onValueChanged.AddListener(delegate { ChooseColors(); });
    }

    void ChooseColors()
    {
        if (myToggle.isOn)
        {
            myImage.color = selectedColor;
        }
        else
        {
            myImage.color = Color.white;
        }
    }
}
