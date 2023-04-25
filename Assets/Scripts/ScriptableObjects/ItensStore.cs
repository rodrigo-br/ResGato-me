using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(menuName = "StoreItem", fileName = "newItem")]
public class ItensStore : ScriptableObject
{
    public string itemName;
    [TextArea(minLines:2, maxLines:5)]public string itemDescription;
    public int itemValue = 0;
    [Header("Choose What to Modify")]
    public bool alteraAgua;
    public bool alteraComida;
    public int alteraComidaFixo = 0;
    public int alteraAguaFixo = 0;
    public float alteraVelocidadeBarraComidaSegundos = 0f;
    public float alteraVelocidadeBarraAguaSegundos = 0f;
    public int alteraConsumoComidaFixo = 0;
    public int alteraConsumoAguaFixo = 0;
    public float alteraComidaPorcentagem = 0f;
    public float alteraAguaPorcentagem = 0f;
    public float alteraVelocidadeBarraComidaPorcentagem = 0f;
    public float alteraVelocidadeBarraAguaPorcentagem = 0f;
    public float alteraConsumoComidaPorcentagem = 0f;
    public float alteraConsumoAguaPorcentagem = 0f;
}