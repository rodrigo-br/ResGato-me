using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : Singleton<MoneyCounter>
{
    public delegate void MoneyChange();
    public event MoneyChange OnMoneyChange;
    [SerializeField] int currentSalary = 50;
    public int MoneyAmount { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        MoneyAmount = 0;
    }

    public void ChangeMoneyAmount(int value)
    {
        MoneyAmount += value;
        OnMoneyChange();
    }

    public void Work()
    {
        ChangeMoneyAmount(currentSalary);
    }

    public void ChangeSalaryByValue(int value)
    {
        currentSalary += value;
    }

    public void ChangeSalaryByPercent(float percent)
    {
        currentSalary += Mathf.CeilToInt(percent / 100 * currentSalary);
    }
}
