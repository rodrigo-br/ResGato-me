using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] Button workButton;
    [SerializeField] Button storeButton;
    [SerializeField] Button otherButton;
    [SerializeField] MoneyCounter moneyCounter;

    void Awake()
    {
        if (workButton)
        {
            workButton.onClick.AddListener(moneyCounter.Work);
        }
        if (storeButton)
        {
            storeButton.onClick.AddListener(EnterStore);
        }
        if (otherButton)
        {
            otherButton.onClick.AddListener(OtherBehavior);
        }
    }

    void EnterStore()
    {
        if (SceneManager.GetActiveScene().name != "StoreScene")
        {
            SceneManager.LoadScene("StoreScene");
        }
    }

    void OtherBehavior()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
