using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Crate : BaseCounter
{
    [SerializeField] private GameObject prefab;
    public override void Interact(Player player)
    {
        //玩家沒東西
        if (!player.HasKitchenObject())
        {
            //給玩家東西
            KitchenObject kitchenObject = Instantiate(prefab).GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
        }
    }
}
