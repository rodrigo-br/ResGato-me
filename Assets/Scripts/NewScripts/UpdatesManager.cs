using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class UpdatesManager : MonoBehaviour
{
    [SerializeField] ClickUpdates updatesPrefab;
    [SerializeField] SOReferences sOReferences;
    NewButtonsManager myNewButtonsManager;
    List<ClickUpdates> myClickUpdatesList;
    public double idTracking { get; private set; } = 0;

    void Awake()
    {
        myNewButtonsManager = FindObjectOfType<NewButtonsManager>();
    }

    void Start()
    {
        myClickUpdatesList = new List<ClickUpdates>();
        foreach (UpgradeItem newUpgradeItem in sOReferences.soreferences)
        {
            ClickUpdates instance = Instantiate<ClickUpdates>(updatesPrefab, transform);
            instance.SetUpgradeItem(newUpgradeItem);
            myNewButtonsManager.SetUpgradeButtonClick(instance);
            myClickUpdatesList.Add(instance);
            instance.OnLevelChanged += RaiseInfoEvent;
        }
    }

    void OnEnable()
    {
        if (myClickUpdatesList == null || myClickUpdatesList.Count <= 0)
        {
            return ;
        }
        foreach (ClickUpdates clickupdate in myClickUpdatesList)
        {
            clickupdate.OnLevelChanged += RaiseInfoEvent;
        }
    }

    void OnDisable()
    {
        foreach (ClickUpdates clickupdate in myClickUpdatesList)
        {
            clickupdate.OnLevelChanged -= RaiseInfoEvent;
        }
    }

    private void RaiseInfoEvent(object sender, EventHandlerClasses e)
    {
        if (e.Id == idTracking && e.Level >= 10)
        {
            idTracking++;
        }
    }
}
