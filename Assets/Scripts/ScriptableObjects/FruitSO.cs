using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Fruit", menuName = "Collactable/FruitScriptableObject", order = 1)]
public class FruitSO : ScriptableObject
{
    public string fruitName;
    public GameObject applePrefab;
    public float weight;
    public Image image;
}
