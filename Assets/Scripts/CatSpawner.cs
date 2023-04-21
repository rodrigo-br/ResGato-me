using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    [SerializeField] GameObject cat;
    RectTransform rectTransform;

    void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void InstantiateCat()
    {
        Vector2 position = new Vector2(Random.Range(0, rectTransform.rect.width), Random.Range(0, rectTransform.rect.height));
        GameObject instance = Instantiate(cat);
        RectTransform instanceRectTransform = instance.GetComponent<RectTransform>();
        instanceRectTransform.SetParent(this.transform);
        Quaternion rotation = Random.Range(0, 1f) >= 0.5 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;
        instanceRectTransform.SetLocalPositionAndRotation(position, rotation);
    }
}
