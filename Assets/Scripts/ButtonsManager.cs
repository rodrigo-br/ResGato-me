using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public delegate void MoneyChange();
    public event MoneyChange OnMoneyChange;

    [SerializeField] Button workButton;
    [SerializeField] Button storeButton;
    [SerializeField] Button otherButton;
    MoneyCounter moneyCounter;

    void Awake()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
        if (workButton)
        {
            workButton.onClick.AddListener(WorkButton);
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

    void WorkButton()
    {
        moneyCounter.Work();
        OnMoneyChange();
    }

    void EnterStore()
    {
        if (SceneManager.GetActiveScene().name != "StoreScene")
        {
            SceneManager.LoadScene("StoreScene");
            FindObjectOfType<CatSpawner>().gameObject.SetActive(false);
        }
    }

    void OtherBehavior()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            SceneManager.LoadScene("MainScene");
            FindObjectOfType<CatSpawner>(true).gameObject.SetActive(true);
        }
    }
}
