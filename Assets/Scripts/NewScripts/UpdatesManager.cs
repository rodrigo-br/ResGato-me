using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UpdatesManager : MonoBehaviour
{
    [SerializeField] ClickUpdates updatesPrefab;
    NewButtonsManager myNewButtonsManager;

    void Awake()
    {
        myNewButtonsManager = FindObjectOfType<NewButtonsManager>();
    }

    void Start()
    {
        string[] assetNames = AssetDatabase.FindAssets("", new[]{"Assets/Scripts/NewScripts/SOs/Itens"});

        foreach (string SOName in assetNames)
        {
            var SOpath    = AssetDatabase.GUIDToAssetPath(SOName);
            var SOitem = AssetDatabase.LoadAssetAtPath<UpgradeItem>(SOpath);
            ClickUpdates instance = Instantiate<ClickUpdates>(updatesPrefab, transform);
            myNewButtonsManager.SetUpgradeButtonClick(instance);
            instance.SetUpgradeItem(SOitem);
        }
    }
}
