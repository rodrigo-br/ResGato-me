using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

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
            myNewButtonsManager.SetUpgradeButtonClick(instance);
            instance.SetUpgradeItem(newUpgradeItem);
        }
    }
}
