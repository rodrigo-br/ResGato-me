using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreOffers : MonoBehaviour
{
    [SerializeField] ItensStore item;
    [SerializeField] TextMeshProUGUI itemDescription;
    Button myButton;
    MoneyCounter myMoneyCounter;
    SliderGroup mySliderGroup;

    void Awake()
    {
        myButton = GetComponentInChildren<Button>();
        myMoneyCounter = FindObjectOfType<MoneyCounter>();
        mySliderGroup = FindObjectOfType<SliderGroup>();
    }

    void Start()
    {
        myButton.onClick.AddListener(BuyItem);
        if (item)
        {
            myButton.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
            itemDescription.text = item.itemDescription;
        }
    }

    void BuyItem()
    {
        if (myMoneyCounter.MoneyAmount < item.itemValue)
        {
            Debug.Log("NO MONEY");
            return ;
        }
        myMoneyCounter.ChangeMoneyAmount(-item.itemValue);
        Debug.Log("BOUGHT " + item.itemName);
        if (item.alteraComida)
        {
            mySliderGroup.UpdateAtributes(0, item.alteraComidaFixo,
                                            item.alteraConsumoComidaFixo,
                                            item.alteraVelocidadeBarraComidaSegundos,
                                            item.alteraComidaPorcentagem,
                                            item.alteraConsumoComidaPorcentagem,
                                            item.alteraVelocidadeBarraComidaPorcentagem);
        }
        if (item.alteraAgua)
        {
            mySliderGroup.UpdateAtributes(1, item.alteraAguaFixo,
                                            item.alteraConsumoAguaFixo,
                                            item.alteraVelocidadeBarraAguaSegundos,
                                            item.alteraAguaPorcentagem,
                                            item.alteraConsumoAguaPorcentagem,
                                            item.alteraVelocidadeBarraAguaPorcentagem);
        }
    }
}
