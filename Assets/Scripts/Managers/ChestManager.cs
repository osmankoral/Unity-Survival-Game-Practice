using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : InteractanleManager
{
    [SerializeField] private ChestSO chest;

    private void Start()
    {
        Instantiate(chest.chestPrefab, transform);
    }

    protected override void InterectFuntcion()
    {
        Vector2 m = transform.position; m.y += 0.2f;
        transform.position = m;
    }
    protected override void InterectInfoFuntcion()
    {
        Debug.Log("merhaba ben " + chest.ChestName);
        Debug.Log("benim aðýrlýðým " + chest.weight);
    }

}
