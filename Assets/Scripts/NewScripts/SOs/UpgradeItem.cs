using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newUpgradeItem", menuName = "Upgrade Item SO")]
public class UpgradeItem : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] string _itemName;
    [SerializeField] string _baseCostMultiplier;
    [SerializeField] string _baseCost;
    [SerializeField] string _earnPower;
    [SerializeField] string _earnProduction;
    [SerializeField] Sprite _image;
    [SerializeField] double _unblockValue;
    public int      id => _id;
    public string   itemName => _itemName;
    public string   baseCostMultiplier => _baseCostMultiplier;
    public string   baseCost => _baseCost;
    public string   earnPower => _earnPower;
    public string   earnProduction => _earnProduction;
    public Sprite   image => _image;
    public double   unblockValue => _unblockValue;
}
