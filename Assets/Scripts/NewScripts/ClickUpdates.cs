using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using TMPro;
using UnityEngine.UI;

public class ClickUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TMP_Text powerText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image itemImage;
    NewButtonsManager newButtonsManager;
    UpgradeItem upgradeItem;
    BigDouble   upgradeBaseCost;
    BigDouble   upgradeCostMultiplier;
    BigDouble   earnPower;
    BigDouble   level;

    void Awake()
    {
        newButtonsManager = FindObjectOfType<NewButtonsManager>();
    }

    public void SetUpgradeItem(UpgradeItem newUpgradeItem)
    {
        upgradeItem = newUpgradeItem;
        upgradeBaseCost = BigDouble.Parse(upgradeItem.baseCost);
        upgradeCostMultiplier = BigDouble.Parse(upgradeItem.baseCostMultiplier);
        itemImage.sprite = upgradeItem.image;
        nameText.text = upgradeItem.itemName;
        earnPower = BigDouble.Parse(upgradeItem.earnPower);
        level = 1;
        UpdateValueText();
    }

    void OnEnable()
    {
        newButtonsManager.OnXOptionClick += UpdateValueText;
    }

    void OnDisable()
    {
        newButtonsManager.OnXOptionClick -= UpdateValueText;
    }

    public void UpdateValueText()
    {
        switch (newButtonsManager.buyXOption)
        {
            case 1:
            {
                costText.text = $"Cost: {UpgradeCost().Notate()}";
                powerText.text = $"+{earnPower.Notate()} Click Power";
                break;
            }
            case 10:
            {
                ShowPrice10();
                break;
            }
            default:
            {
                ShowPriceMax();
                break;
            }
        }
        levelText.text = "Level " + level;
    }

    public void LevelUp(double amount = 1)
    {
        BigDouble levelUpAmount;
        switch (amount)
        {
            case 1:
            {
                levelUpAmount = 1;
                break;
            }
            case 10:
            {
                levelUpAmount = 10;
                break;
            }
            default:
            {
                BigDouble playerMoney = newButtonsManager.GetPlayerMoney();
                BigDouble n = BigDouble.Floor(BigDouble.Log(playerMoney * (upgradeCostMultiplier - 1) / UpgradeCost() + 1, upgradeCostMultiplier));
                levelUpAmount = n;
                break;
            }  
        }
        level += levelUpAmount;
    }

    public BigDouble GetEarnPower(double amount = 1) => earnPower * amount;

    public BigDouble UpgradeCost(double amount = 1)
    {
        switch (amount)
        {
            case 1:
                return (upgradeBaseCost * BigDouble.Pow(upgradeCostMultiplier, level));
            case 10:
                return UpgradeCost() * ((BigDouble.Pow(upgradeCostMultiplier, 10) - 1) / (upgradeCostMultiplier - 1));
            default:
            {
                BigDouble playerMoney = newButtonsManager.GetPlayerMoney();
                BigDouble n = BigDouble.Floor(BigDouble.Log(playerMoney * (upgradeCostMultiplier - 1) / UpgradeCost() + 1, upgradeCostMultiplier));
                return UpgradeCost() * ((BigDouble.Pow(upgradeCostMultiplier, n) - 1) / (upgradeCostMultiplier - 1));
            }
        }
    }

    void ShowPriceMax()
    {
        BigDouble playerMoney = newButtonsManager.GetPlayerMoney();
        BigDouble n = BigDouble.Floor(BigDouble.Log(playerMoney * (upgradeCostMultiplier - 1) / UpgradeCost() + 1, upgradeCostMultiplier));
        BigDouble cost = UpgradeCost() * ((BigDouble.Pow(upgradeCostMultiplier, n) - 1) / (upgradeCostMultiplier - 1));
        if (n > 0)
        {
            costText.text = $"Cost: {cost.Notate()}";
            powerText.text = $"+{(earnPower * n).Notate()} Click Power";
        }
        else
        {
            costText.text = ":(";
            powerText.text = $"0 Click Power";
        }
    }

    void ShowPrice10()
    {
        BigDouble cost = UpgradeCost() * ((BigDouble.Pow(upgradeCostMultiplier, 10) - 1) / (upgradeCostMultiplier - 1));
        costText.text = $"Cost: {cost.Notate()}";
        powerText.text = $"+{(earnPower * 10).Notate()} Click Power";
    }
}
