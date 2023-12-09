using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        //桌上沒東西
        if (!HasKitchenObject())
        {
            //玩家有東西
            if (player.HasKitchenObject())
            {
                //放東西
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        //桌上有東西
        else
        {
            //玩家沒東西
            if (!player.HasKitchenObject())
            {
                //拿東西
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
            //玩家有東西
            else
            {
                //玩家有盤子
                if (player.GetKitchenObject() is Plate)
                {
                    //拿盤子裝食材
                    Plate plate = player.GetKitchenObject() as Plate;
                    Ingredient ingredient = this.GetKitchenObject() as Ingredient;
                    if (plate.AddIngredient(ingredient))
                    {
                        this.GetKitchenObject().DestroySelf();
                    }
                }
                else if (this.GetKitchenObject() is Plate)
                {
                    Plate plate = this.GetKitchenObject() as Plate;
                    Ingredient ingredient = player.GetKitchenObject() as Ingredient;
                    if (plate.AddIngredient(ingredient))
                    {
                        player.GetKitchenObject().DestroySelf();
                    }
                }
            }
        }
    }
}
