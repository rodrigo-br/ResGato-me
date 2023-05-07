using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogueManager : MonoBehaviour
{
    public delegate void CatalogueGenerated();
    public event CatalogueGenerated OnCatalogueGenerated;
    [SerializeField] CatsSO[] mvpCats;
    [SerializeField] CatsSO[] ordinaryCats;
    [SerializeField] CatsSO[] rareCats;
    List<CatsSO> catalogueList;
    List<CatsSO> resultList;

    void Start()
    {
        catalogueList = new List<CatsSO>();
        resultList = new List<CatsSO>();
        catalogueList.Add(mvpCats[Random.Range(0, mvpCats.Length)]);
        for (int i = 0; i < 9; i++)
            catalogueList.Add(rareCats[Random.Range(0, rareCats.Length)]);
        for (int i = 0; i < 90; i++)
            catalogueList.Add(ordinaryCats[Random.Range(0, ordinaryCats.Length)]);
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            GenerateCatalogue();
        }
    }

    void GenerateCatalogue()
    {
        if (catalogueList.Count < 4)
        {
            return ;
        }
        if (resultList.Count == 4)
        {
            resultList.Clear();
        }
        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, catalogueList.Count);
            resultList.Add(catalogueList[index]);
            catalogueList.RemoveAt(index);
            if (resultList.Count == 4)
            {
                if (OnCatalogueGenerated != null)
                {
                    OnCatalogueGenerated();
                }
            }
        }
    }

    public List<CatsSO> GetResultList()
    {
        return resultList;
    } 
}
