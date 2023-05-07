using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatesManager : MonoBehaviour
{
    [SerializeField] ClickUpdates updatesPrefab;
    [SerializeField] SOReferences sOReferences;
    NewButtonsManager myNewButtonsManager;

    void Awake()
    {
        myNewButtonsManager = FindObjectOfType<NewButtonsManager>();
    }

    void Start()
    {
        foreach (UpgradeItem newUpgradeItem in sOReferences.soreferences)
        {
            ClickUpdates instance = Instantiate<ClickUpdates>(updatesPrefab, transform);
            instance.SetUpgradeItem(newUpgradeItem);
            myNewButtonsManager.SetUpgradeButtonClick(instance);
        }
    }
}
