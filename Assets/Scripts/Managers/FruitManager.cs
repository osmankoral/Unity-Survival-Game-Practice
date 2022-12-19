using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : CollactableManager
{
    [SerializeField] private FruitSO fruit;
    

    private void Start()
    {
        Instantiate(fruit.applePrefab, transform);
    }

    protected override void InterectFuntcion()
    {
        DestroyGameObject(0);
    }

    protected override void InterectInfoFuntcion()
    {
        Debug.Log("merhaba ben " + fruit.fruitName);
        Debug.Log("benim aðýrlýðým " + fruit.weight);
        
    }

    private void OnEnable()
    {
        
    }



}
