using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCatSO", menuName = "CatsSO")]
public class CatsSO : ScriptableObject
{
    [SerializeField] string _catName;
    [SerializeField] Sprite _catImage;
    [SerializeField] double _deltaCatAmount;
    public string catName => _catName;
    public Sprite catImage => _catImage;
    public double deltaCatAmount => _deltaCatAmount;
}
