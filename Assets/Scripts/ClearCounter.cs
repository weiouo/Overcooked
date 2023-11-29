using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        Debug.Log("interact");
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                //©ñ­¹§÷
                player.ReturnKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else 
        {
            if (!player.HasKitchenObject())
            {
                ReturnKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
