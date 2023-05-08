using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatOffer : MonoBehaviour
{
    [SerializeField] Image catImage;
    [SerializeField] TextMeshProUGUI deltaLevel;
    [SerializeField] TextMeshProUGUI infos;

    public Image GetCatImage() => catImage;

    public TextMeshProUGUI GetDeltaLevel() => deltaLevel;

    public TextMeshProUGUI GetInfos() => infos;

    public Button GetCatOfferButton() => catImage.gameObject.GetComponent<Button>();
}
