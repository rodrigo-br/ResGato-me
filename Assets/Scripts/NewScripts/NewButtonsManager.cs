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
    [SerializeField] Canvas[] popUpCanvas;

    void Awake()
    {
        settingsButton.onClick.AddListener(() => SelectCanvas("Settings"));
        storeButton.onClick.AddListener(() => SelectCanvas("Store"));
        adoptButton.onClick.AddListener(() => SelectCanvas("Adopt"));
        achivButton.onClick.AddListener(() => SelectCanvas("Achiev"));
        noAdsButton.onClick.AddListener(() => SelectCanvas("NoAds"));
        clickButton.onClick.AddListener(() => myPlayerStatus.EarnCoinOnClick());
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

    public void SetUpgradeButtonClick(Button button)
    {
        button.onClick.AddListener(() => OnUpgradeButtonClick(button));
    }

    void OnUpgradeButtonClick(Button self)
    {
        ClickUpdates myClickUpdates = self.GetComponentInParent<ClickUpdates>();
        if (myPlayerStatus.GetCoinAmount() >= myClickUpdates.UpgradeCost())
        {
            myPlayerStatus.BuySomething(myClickUpdates.UpgradeCost());
            myClickUpdates.LevelUp();
            myPlayerStatus.PowerEarnings(myClickUpdates.GetEarnPower());
        }
        myClickUpdates.UpdateValueText();
    }
}
