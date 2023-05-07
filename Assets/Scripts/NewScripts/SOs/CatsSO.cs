using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCatSO", menuName = "CatsSO")]
public class CatsSO : ScriptableObject
{
    public string catName;
    public Sprite catImage;
    public double deltaCatAmount;
}
