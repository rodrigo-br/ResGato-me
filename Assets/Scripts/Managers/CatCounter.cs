using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCounter : Singleton<CatCounter>
{
    public int CatAmount { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        CatAmount = 0;
    }

    void DebugginCats()
    {
        if (Input.GetKeyDown("c"))
        {
            ChangeCatAmount(1);
        }
        if (Input.GetKeyDown("d"))
        {
            ChangeCatAmount(-1);
            Destroy(FindAnyObjectByType<Cat>().gameObject);
        }
    }

    public void ChangeCatAmount(int value)
    {
        CatAmount += value;
        if (CatAmount < 0)
        {
            CatAmount = 0;
            value = 0;
        }
    }
}
