using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using UnityEngine.UI;
using TMPro;

public class ClickUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TMP_Text powerText;
    [SerializeField] UpgradeItem upgradeItem;
    BigDouble   upgradeBaseCost;
    BigDouble   upgradeCostMultiplier;
    BigDouble   earnPower;
    BigDouble   level;

    void Start()
    {
        upgradeBaseCost = BigDouble.Parse(upgradeItem.baseCost);
        upgradeCostMultiplier = BigDouble.Parse(upgradeItem.baseCostMultiplier);
        earnPower = BigDouble.Parse(upgradeItem.earnPower);
        level = 1;
        UpdateValueText();
    }

    public void UpdateValueText()
    {
        costText.text = $"Cost: {UpgradeCost().ToString("F2")}";
        powerText.text = $"+{earnPower} Click Power";
    }

    public void LevelUp() => level++;

    public BigDouble GetEarnPower() => earnPower;

    public BigDouble UpgradeCost()
    {
        return (upgradeBaseCost * BigDouble.Pow(upgradeCostMultiplier, level));
    }
}
