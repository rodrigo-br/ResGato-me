using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "StoreItem", fileName = "newItem")]
public class ItensStore : ScriptableObject
{
    [SerializeField] string itemName;
    [TextArea(minLines:2, maxLines:5)][SerializeField] string itemDescription;
    [SerializeField] int itemValue = 0;
    [SerializeField] int alteraComidaFixo = 0;
    [SerializeField] int alteraAguaFixo = 0;
    [SerializeField] float alteraComidaPorcentagem = 0f;
    [SerializeField] float alteraAguaPorcentagem = 0f;
    [SerializeField] float alteraVelocidadeBarraSegundos = 0f;
    [SerializeField] float alteraVelocidadeBarraPorcentagem = 0f;
    [SerializeField] int alteraConsumoComidaFixo = 0;
    [SerializeField] float alteraConsumoComidaPorcentagem = 0f;
    [SerializeField] int alteraConsumoAguaFixo = 0;
    [SerializeField] float alteraConsumoAguaPorcentagem = 0f;
}
