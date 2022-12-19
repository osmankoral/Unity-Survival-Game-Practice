using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Chest", menuName = "Collactable/ChestScriptableObject", order = 1)]
public class ChestSO : ScriptableObject
{
    public string ChestName;
    public GameObject chestPrefab;
    public float weight;
}
