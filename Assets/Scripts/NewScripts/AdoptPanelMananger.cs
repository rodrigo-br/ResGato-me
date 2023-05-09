using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdoptPanelMananger : MonoBehaviour
{
    [SerializeField] CatOffer catOfferPrefab;
    [SerializeField] UpdatesManager myUpdatesManager;
    CatalogueManager myCatalogueManager;
    NewButtonsManager myNewButtonsManager;
    List<CatsSO> catsList;
    public bool isAdopting { get; private set; } = true;
    double isTracking = 0;

    void Awake()
    {
        myCatalogueManager = FindObjectOfType<CatalogueManager>();
        myNewButtonsManager = FindObjectOfType<NewButtonsManager>();
    }

    void Start()
    {
        InstantiateList();
    }

    void OnEnable()
    {
        if (myUpdatesManager.idTracking > isTracking)
        {
            isTracking++;
            SetIsAdopting(true);
        }
        myCatalogueManager.OnCatalogueGenerated += InstantiateList;
        myNewButtonsManager.OnCatOfferSelect += () => SetIsAdopting(false);
    }

    void OnDisable()
    {
        myCatalogueManager.OnCatalogueGenerated -= InstantiateList;
        myNewButtonsManager.OnCatOfferSelect -= () => SetIsAdopting(false);
    }

    void SetIsAdopting(bool value)
    {
        isAdopting = value;
        if (isAdopting)
        {
            InstantiateList();
        }
        else
        {
            DestroyOffers();
        }
    }

    void InstantiateList()
    {
        if (!isAdopting)
        {
            return ;
        }
        catsList = myCatalogueManager.GetResultList();
        DestroyOffers();
        for (int i = 0; i < catsList.Count; i++)
        {
            CatOffer catOffer = Instantiate<CatOffer>(catOfferPrefab, transform);
            catOffer.GetCatImage().sprite = catsList[i].catImage;
            catOffer.GetInfos().text = catsList[i].catName;
            catOffer.GetDeltaLevel().text = catsList[i].deltaCatAmount.ToString();
            myNewButtonsManager.SetCatOfferButton(catOffer.GetCatOfferButton(), catsList[i].deltaCatAmount);
        }
    }

    void DestroyOffers()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
