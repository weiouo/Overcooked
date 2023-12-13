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
                if (GetKitchenObject() is Pan)
                {
                    Pan pan = GetKitchenObject() as Pan;
                    if (!pan.HasKitchenObject())
                    {
                        pan.SetKitchenObjectParent(player);
                    }
                    else
                    {
                        Ingredient ingredient = pan.GetKitchenObject() as Ingredient;
                        if (!ingredient.IsComplete())
                        {
                            pan.GetKitchenObject().SetKitchenObjectParent(player);
                        }
                    }

                }
                else
                {
                    //拿東西
                    this.GetKitchenObject().SetKitchenObjectParent(player);
                }
            }
            //玩家有東西
            else
            {
                //玩家有盤子
                if (player.GetKitchenObject() is Plate)
                {
                    Plate plate = player.GetKitchenObject() as Plate;
                    if (GetKitchenObject() is Pan)
                    {
                        Pan pan = GetKitchenObject() as Pan;
                        if (pan.HasKitchenObject())
                        {
                            Ingredient ingredient = pan.GetKitchenObject() as Ingredient;
                            if (ingredient.IsComplete())
                            {
                                if (plate.AddIngredient(ingredient))
                                {
                                    pan.GetKitchenObject().DestroySelf();
                                }
                            }
                        }
                    }
                    else
                    {
                        Ingredient ingredient = GetKitchenObject() as Ingredient;
                        if (plate.AddIngredient(ingredient))
                        {
                            this.GetKitchenObject().DestroySelf();
                        }
                    }
                }
                else if (this.GetKitchenObject() is Plate && player.GetKitchenObject() is Ingredient)
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
