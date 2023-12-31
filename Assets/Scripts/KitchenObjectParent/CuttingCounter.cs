using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CuttingCounter : ClearCounter
{
    private Ingredient ingredient;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() & player.GetKitchenObject() is Ingredient)
            {
                ingredient = player.GetKitchenObject() as Ingredient;
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                ingredient = null;
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
            else if (player.GetKitchenObject() is Plate && ingredient.IsComplete())
            {
                Plate plate = player.GetKitchenObject() as Plate;
                Ingredient ingredient = this.GetKitchenObject() as Ingredient;
                if (plate.AddIngredient(ingredient))
                {
                    this.GetKitchenObject().DestroySelf();
                }
            }
            else if (player.GetKitchenObject() is Pan && ingredient.CanPanfried()) 
            {
                Pan pan = player.GetKitchenObject() as Pan;
                this.GetKitchenObject().SetKitchenObjectParent(pan);
            }
        }
    }

    public override void Cut(Player player)
    {
        //試圖獲取該食材
        ingredient = this.GetKitchenObject() is Ingredient ? this.GetKitchenObject() as Ingredient : null;
        //有食材才能切
        if (ingredient != null && ingredient.CanCut())
        {
            ingredient.Cut();
            player.HandleCutAnimation(true);
        }
        else
        {
            player.HandleCutAnimation(false);
        }
    }
}
