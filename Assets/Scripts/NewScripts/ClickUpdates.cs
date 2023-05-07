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
    [SerializeField] Image blockImage;
    NewButtonsManager newButtonsManager;
    UpgradeItem upgradeItem;
    BigDouble   upgradeBaseCost;
    BigDouble   upgradeCostMultiplier;
    BigDouble   earnPower;
    BigDouble   level;
    public double unblockValue { get; private set; }
    string      powerTypeText = "Click Power";
    public bool isProduction { get; private set; } = false;

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
        if (upgradeItem.earnPower.Length > 0)
        {
            earnPower = BigDouble.Parse(upgradeItem.earnPower);
        }
        else
        {
            isProduction = true;
            earnPower = BigDouble.Parse(upgradeItem.earnProduction);
            powerTypeText = "/sec";
        }
        level = 1;
        unblockValue = upgradeItem.unblockValue;
        UpdateValueText();
    }

    void OnEnable()
    {
        newButtonsManager.OnXOptionClick += UpdateValueText;
        StopCoroutine(UpdateTextCoroutine());
        StartCoroutine(UpdateTextCoroutine());
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
                costText.text = $"Cost: {Get1Cost().Notate()}";
                powerText.text = $"+{earnPower.Notate()} {powerTypeText}";
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
        levelText.text = "Lvl " + level;
    }

    public void LevelUp(BigDouble amount) => level += amount;

    public BigDouble GetEarnPower(BigDouble amount) => earnPower * amount;

    public BigDouble GetCorrectLevel(int XOption)
    {
        switch(XOption)
        {
            case 1:
                return 1;
            case 10:
                return 10;
            default:
                return GetMaxLevels();
        }
    }

    public BigDouble GetCorrectCost(int XOption)
    {
        switch(XOption)
        {
            case 1:
                return Get1Cost();
            case 10:
                return Get10Cost();
            default:
                return GetMaxCost();
        }
    }

    BigDouble GetMaxLevels()
    {
        BigDouble playerMoney = newButtonsManager.GetPlayerMoney();
        return BigDouble.Floor(BigDouble.Log(playerMoney * (upgradeCostMultiplier - 1) / Get1Cost() + 1, upgradeCostMultiplier));
    }

    BigDouble GetMaxCost()
    {
        return Get1Cost() * ((BigDouble.Pow(upgradeCostMultiplier, GetMaxLevels()) - 1) / (upgradeCostMultiplier - 1));
    }

    BigDouble Get10Cost()
    {
        return Get1Cost() * ((BigDouble.Pow(upgradeCostMultiplier, 10) - 1) / (upgradeCostMultiplier - 1));
    }

    BigDouble Get1Cost()
    {
        return upgradeBaseCost * BigDouble.Pow(upgradeCostMultiplier, level);
    }

    void ShowPriceMax()
    {
        BigDouble n = GetMaxLevels();
        if (n > 0)
        {
            costText.text = $"Cost: {GetMaxCost().Notate()}";
            powerText.text = $"+{(earnPower * n).Notate()} {powerTypeText}\n(+{n} levels)";
        }
        else
        {
            costText.text = ":(";
            powerText.text = $"0 {powerTypeText}";
        }
    }

    void ShowPrice10()
    {
        BigDouble cost = Get10Cost();
        costText.text = $"Cost: {cost.Notate()}";
        powerText.text = $"+{(earnPower * 10).Notate()} {powerTypeText}";
    }

    IEnumerator UpdateTextCoroutine()
    {
        while (true)
        {
            UpdateValueText();
            yield return new WaitForSecondsRealtime(0.6f);
        }
    }

    public void BlockImage()
    {
        blockImage.gameObject.SetActive(true);
    }

    public void UnblockImage()
    {
        blockImage.gameObject.SetActive(false);
    }
}
