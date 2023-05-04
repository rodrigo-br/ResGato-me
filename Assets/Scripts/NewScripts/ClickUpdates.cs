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
                Buy10();gi
                break;
            }
            default:
            {
                BuyMax();
                break;
            }
        }
        levelText.text = "Level " + level;
    }

    public void LevelUp() => level++;

    public BigDouble GetEarnPower() => earnPower;

    public BigDouble UpgradeCost()
    {
        return (upgradeBaseCost * BigDouble.Pow(upgradeCostMultiplier, level));
    }

    void BuyMax()
    {
        BigDouble playerMoney = newButtonsManager.GetPlayerMoney();
        BigDouble n = BigDouble.Floor((BigDouble)BigDouble.Log(playerMoney * (upgradeCostMultiplier - 1) / UpgradeCost() + 1, upgradeCostMultiplier));
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

    void Buy10()
    {
        BigDouble cost = UpgradeCost() * ((BigDouble.Pow(upgradeCostMultiplier, 10) - 1) / (upgradeCostMultiplier - 1));
        costText.text = $"Cost: {cost.Notate()}";
        powerText.text = $"+{(earnPower * 10).Notate()} Click Power";
    }
}
