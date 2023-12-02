using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Crate : BaseCounter
{
    [SerializeField] private KichenObjectSO KichenObjectSO;

    public override void Interact(Player player)
    {
        //玩家沒東西
        if (!player.HasKitchenObject())
        {
            //給玩家東西
            KitchenObject kitchenObject = Instantiate(KichenObjectSO.prefab).GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
        }
        //玩家有東西
        else
        {
            Debug.LogError("Already had KitchenObject");
        }
    }
}
