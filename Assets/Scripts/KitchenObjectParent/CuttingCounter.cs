using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CuttingCounter : ClearCounter
{
    public delegate void CutEventHandler(bool isCutting);
    public static event CutEventHandler CutBool;
    private Ingredient ingredient;
    public override void Interact(Player player)
    {
        //桌上沒東西
        if (!HasKitchenObject())
        {
            //玩家有東西 & 該東西是食材
            if (player.HasKitchenObject() & player.GetKitchenObject() is Ingredient)
            {
                //放食材
                ingredient = player.GetKitchenObject() as Ingredient;
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        //桌上有東西
        else
        {
            //玩家沒東西
            if (!player.HasKitchenObject())
            {
                //拿食材
                ingredient = null;
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
            else if (player.GetKitchenObject() is Plate && ingredient.IsProcessFinished())
            {
                //拿盤子裝食材
                Plate plate = player.GetKitchenObject() as Plate;
                Ingredient ingredient = this.GetKitchenObject() as Ingredient;
                if (plate.AddIngredient(ingredient))
                {
                    this.GetKitchenObject().DestroySelf();
                }
            }
        }
    }
    public override void Cut()
    {
        //試圖獲取該食材
        ingredient = this.GetKitchenObject() is Ingredient ? this.GetKitchenObject() as Ingredient : null;
        //有食材才能切
        if (ingredient != null && ingredient.CanCut())
        {
            ingredient.Cut();
            CutBool?.Invoke(true);
        }
        else
        {
            CutBool?.Invoke(false);
        }
    }
}
