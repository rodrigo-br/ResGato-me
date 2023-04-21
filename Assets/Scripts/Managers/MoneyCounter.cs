using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : Singleton<MoneyCounter>
{
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

    void ChangeMoneyAmount(int value)
    {
        MoneyAmount += value;
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
