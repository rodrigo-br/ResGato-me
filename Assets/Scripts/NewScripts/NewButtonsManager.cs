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

    void Awake()
    {
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        storeButton.onClick.AddListener(OnStoreButtonClick);
        adoptButton.onClick.AddListener(OnAdoptButtonClick);
        achivButton.onClick.AddListener(OnAchievButtonClick);
        noAdsButton.onClick.AddListener(OnNoAdsButtonClick);
        clickButton.onClick.AddListener(OnClickButtonClick);
    }

    void OnSettingsButtonClick() => Debug.Log("SettingsButtonClick");

    void OnStoreButtonClick() => Debug.Log("StoreButtonClick");

    void OnAdoptButtonClick() => Debug.Log("AdoptButtonClick");

    void OnAchievButtonClick() => Debug.Log("AchievButtonClick");

    void OnNoAdsButtonClick() => Debug.Log("NoAdsButtonClick");

    void OnClickButtonClick()
    {
        myPlayerStatus.EarnCoinOnClick();
        Debug.Log("ClickButtonClick");
    }
}
