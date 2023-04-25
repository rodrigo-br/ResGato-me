using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatCounter : Singleton<CatCounter>
{
    public delegate void CatChange();
    public event CatChange OnCatChange;
    public int CatAmount { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        CatAmount = 0;
    }

    void Update()
    {
        DebugginCats();
    }

    void DebugginCats()
    {
        if (Input.GetKeyDown("4"))
        {
            ChangeCatAmount(1);
            CatSpawner instance = FindAnyObjectByType<CatSpawner>();
            if (instance != null)
            {
                instance.InstantiateCat();
            }
        }
        else if (Input.GetKeyDown("5"))
        {
            ChangeCatAmount(-1);
            Cat instance = FindAnyObjectByType<Cat>();
            if (instance != null)
            {
                Destroy(instance.gameObject);
            }
            instance = null;
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
        OnCatChange();
        FindObjectOfType<PlayFabManager>()?.SendLeaderBoard(CatAmount);
    }
}
