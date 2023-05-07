using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdoptPanelMananger : MonoBehaviour
{
    [SerializeField] CatOffer catOfferPrefab;
    CatalogueManager myCatalogueManager;
    List<CatsSO> catsList;

    void Awake()
    {
        myCatalogueManager = FindObjectOfType<CatalogueManager>();
    }

    void Start()
    {
        InstantiateList();
    }

    void OnEnable()
    {
        myCatalogueManager.OnCatalogueGenerated += InstantiateList;
    }

    void OnDisable()
    {
        myCatalogueManager.OnCatalogueGenerated -= InstantiateList;
    }

    void InstantiateList()
    {
        catsList = myCatalogueManager.GetResultList();
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < catsList.Count; i++)
        {
            CatOffer catOffer = Instantiate<CatOffer>(catOfferPrefab, transform);
            catOffer.GetCatImage().sprite = catsList[i].catImage;
            catOffer.GetInfos().text = catsList[i].catName;
            catOffer.GetDeltaLevel().text = catsList[i].deltaCatAmount.ToString();
        }
    }

}
