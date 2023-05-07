using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;

public class NewButtonsManager : MonoBehaviour
{
    public delegate void XOptionClick();
    public event XOptionClick OnXOptionClick;
    [SerializeField] Button settingsButton;
    [SerializeField] Button storeButton;
    [SerializeField] Button adoptButton;
    [SerializeField] Button achivButton;
    [SerializeField] Button noAdsButton;
    [SerializeField] Button clickButton;
    [SerializeField] Toggle buy1X;
    [SerializeField] Toggle buy10X;
    [SerializeField] Toggle buyMAX;
    [SerializeField] PlayerStatus myPlayerStatus;
    [SerializeField] Canvas[] popUpCanvas;
    List<ClickUpdates> myClickUpdatesList;
    public int buyXOption { get; private set; } = 1;

    void Awake()
    {
        settingsButton.onClick.AddListener(() => SelectCanvas("Settings"));
        storeButton.onClick.AddListener(() => SelectCanvas("Store"));
        adoptButton.onClick.AddListener(() => SelectCanvas("Adopt"));
        achivButton.onClick.AddListener(() => SelectCanvas("Achiev"));
        noAdsButton.onClick.AddListener(() => SelectCanvas("NoAds"));
        clickButton.onClick.AddListener(() => myPlayerStatus.EarnCoinOnClick());
        buy1X.onValueChanged.AddListener(delegate { BuyXOptionClick(1); });
        buy10X.onValueChanged.AddListener(delegate { BuyXOptionClick(10); });
        buyMAX.onValueChanged.AddListener(delegate { BuyXOptionClick(-1); });
        myClickUpdatesList = new List<ClickUpdates>();
    }

    void OnEnable()
    {
        myPlayerStatus.OnCatChangeEvent += CheckUnlocksUpdates;
    }

    void CheckUnlocksUpdates()
    {
        List<ClickUpdates> toRemove = new List<ClickUpdates>();
        double catAmount = myPlayerStatus.catAmount.ToDouble();
        if (myClickUpdatesList.Count <= 0)
        {
            return ;
        }
        foreach (ClickUpdates clickupdate in myClickUpdatesList)
        {
            if (catAmount >= clickupdate.unblockValue)
            {
                clickupdate.GetComponentInChildren<Button>().interactable = true;
                clickupdate.UnblockImage();
                toRemove.Add(clickupdate);
            }
        }
        foreach (ClickUpdates clickupdate in toRemove)
        {
            myClickUpdatesList.Remove(clickupdate);
        }
    }

    void SelectCanvas(string canvasTag)
    {
        foreach (Canvas canvas in popUpCanvas)
        {
            if (canvas.CompareTag(canvasTag))
            {
                canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public void SetUpgradeButtonClick(ClickUpdates myClickUpdates)
    {
        Button button = myClickUpdates.GetComponentInChildren<Button>();
        button.onClick.AddListener(() => OnUpgradeButtonClick(myClickUpdates));
        if (myPlayerStatus.catAmount.ToDouble() >= myClickUpdates.unblockValue)
        {
            button.interactable = true;
            myClickUpdates.UnblockImage();
        }
        myClickUpdatesList.Add(myClickUpdates);
    }

    void OnUpgradeButtonClick(ClickUpdates myClickUpdates)
    {
        BigDouble correctCost = myClickUpdates.GetCorrectCost(buyXOption);
        BigDouble correctLevel = myClickUpdates.GetCorrectLevel(buyXOption);
        if (myPlayerStatus.GetCoinAmount() >= correctCost)
        {
            myPlayerStatus.BuySomething(correctCost);
            myClickUpdates.LevelUp(correctLevel);
            myPlayerStatus.PowerEarnings(myClickUpdates.GetEarnPower(correctLevel), myClickUpdates.isProduction);
        }
        myClickUpdates.UpdateValueText();
    }

    void BuyXOptionClick(int value)
    {
        buyXOption = value;
        OnXOptionClick();
    }

    public BigDouble GetPlayerMoney()
    {
        return myPlayerStatus.GetCoinAmount();
    }
}
