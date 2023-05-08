using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOReferences : MonoBehaviour
{
    [SerializeField] UpgradeItem[] _soreferences;

    public UpgradeItem[] soreferences => _soreferences;
}
