using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewButtonsManager : MonoBehaviour
{
    [SerializeField] Button settingsButton;
    [SerializeField] Button storeButton;
    [SerializeField] Button adoptButton;
    [SerializeField] Button achivButton;
    [SerializeField] Button noAdsButton;
    [SerializeField] Button clickButton;
    [SerializeField] PlayerStatus myPlayerStatus;
    [SerializeField] Button[] upgradeButton;
    [SerializeField] Canvas[] popUpCanvas;

    void Awake()
    {
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        storeButton.onClick.AddListener(OnStoreButtonClick);
        adoptButton.onClick.AddListener(OnAdoptButtonClick);
        achivButton.onClick.AddListener(OnAchievButtonClick);
        noAdsButton.onClick.AddListener(OnNoAdsButtonClick);
        clickButton.onClick.AddListener(OnClickButtonClick);
        foreach (Button btn in upgradeButton)
        {
            btn.onClick.AddListener(() => OnUpgradeButtonClick(btn));
        }
    }

    void OnSettingsButtonClick() => SelectCanvas("Settings");

    void OnStoreButtonClick() => SelectCanvas("Store");

    void OnAdoptButtonClick() => SelectCanvas("Adopt");

    void OnAchievButtonClick() => SelectCanvas("Achiev");

    void OnNoAdsButtonClick() => SelectCanvas("NoAds");

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

    void OnClickButtonClick() => myPlayerStatus.EarnCoinOnClick();

    void OnUpgradeButtonClick(Button self)
    {
        ClickUpdates myClickUpdates = self.GetComponent<ClickUpdates>();
        if (myPlayerStatus.GetCoinAmount() >= myClickUpdates.UpgradeCost())
        {
            myPlayerStatus.BuySomething(myClickUpdates.UpgradeCost());
            myClickUpdates.LevelUp();
            myPlayerStatus.PowerEarnings(myClickUpdates.GetEarnPower());
        }
        myClickUpdates.UpdateValueText();
    }
}
