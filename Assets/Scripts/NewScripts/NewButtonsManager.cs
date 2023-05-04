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
    [SerializeField] Button buy1X;
    [SerializeField] Button buy10X;
    [SerializeField] Button buyMAX;
    [SerializeField] PlayerStatus myPlayerStatus;
    [SerializeField] Canvas[] popUpCanvas;
    public int buyXOption { get; private set; } = 1;

    void Awake()
    {
        settingsButton.onClick.AddListener(() => SelectCanvas("Settings"));
        storeButton.onClick.AddListener(() => SelectCanvas("Store"));
        adoptButton.onClick.AddListener(() => SelectCanvas("Adopt"));
        achivButton.onClick.AddListener(() => SelectCanvas("Achiev"));
        noAdsButton.onClick.AddListener(() => SelectCanvas("NoAds"));
        clickButton.onClick.AddListener(() => myPlayerStatus.EarnCoinOnClick());
        buy1X.onClick.AddListener(() => BuyXOptionClick(1));
        buy10X.onClick.AddListener(() => BuyXOptionClick(10));
        buyMAX.onClick.AddListener(() => BuyXOptionClick(-1));
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
    }

    void OnUpgradeButtonClick(ClickUpdates myClickUpdates)
    {
        if (myPlayerStatus.GetCoinAmount() >= myClickUpdates.UpgradeCost())
        {
            myPlayerStatus.BuySomething(myClickUpdates.UpgradeCost());
            myClickUpdates.LevelUp();
            myPlayerStatus.PowerEarnings(myClickUpdates.GetEarnPower());
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
