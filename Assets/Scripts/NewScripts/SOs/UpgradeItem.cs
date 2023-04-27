using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newUpgradeItem", menuName = "Upgrade Item SO")]
public class UpgradeItem : ScriptableObject
{
    public int      id;
    public string   baseCostMultiplier;
    public string   baseCost;
    public string   earnPower;
}
