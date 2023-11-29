using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : BaseCounter
{
    [SerializeField] private KichenObjectSO KichenObjectSO;
    public override void Interact(Player player)
    {
        Debug.Log("interact");
        if (!player.HasKitchenObject())
        {
            Transform kitchenobject_transformation = Instantiate(KichenObjectSO.prefab);
            kitchenobject_transformation.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            Debug.Log(kitchenobject_transformation.GetComponent<KitchenObject>().KichenObject_return(player).objectname);
        }
        else
        {
            Debug.LogError("Already had KitchenObject");
        }
    }
}
