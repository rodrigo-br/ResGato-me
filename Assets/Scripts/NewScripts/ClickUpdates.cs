using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using TMPro;

public class ClickUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TMP_Text powerText;
    [SerializeField] TextMeshProUGUI levelText;
    UpgradeItem upgradeItem;
    BigDouble   upgradeBaseCost;
    BigDouble   upgradeCostMultiplier;
    BigDouble   earnPower;
    BigDouble   level;

    public void SetUpgradeItem(UpgradeItem newUpgradeItem)
    {
        upgradeItem = newUpgradeItem;
        upgradeBaseCost = BigDouble.Parse(upgradeItem.baseCost);
        upgradeCostMultiplier = BigDouble.Parse(upgradeItem.baseCostMultiplier);
        earnPower = BigDouble.Parse(upgradeItem.earnPower);
        level = 1;
        UpdateValueText();
    }

    public void UpdateValueText()
    {
        costText.text = $"Cost: {UpgradeCost().Notate()}";
        powerText.text = $"+{earnPower.Notate()} Click Power";
        levelText.text = "Level " + level;
    }

    public void LevelUp() => level++;

    public BigDouble GetEarnPower() => earnPower;

    public BigDouble UpgradeCost()
    {
        return (upgradeBaseCost * BigDouble.Pow(upgradeCostMultiplier, level));
    }
}
