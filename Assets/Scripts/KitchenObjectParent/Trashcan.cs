using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Trashcan : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject() is Ingredient)
            {
                player.GetKitchenObject().DestroySelf();
            }
            else if (player.GetKitchenObject() is Pan)
            {
                Pan pan = player.GetKitchenObject() as Pan;
                pan.GetKitchenObject().DestroySelf();
            }
            else if (player.GetKitchenObject() is Plate)
            {
                Plate plate = player.GetKitchenObject() as Plate;
                plate.ClearIngredient();
            }
        }
    }
}
