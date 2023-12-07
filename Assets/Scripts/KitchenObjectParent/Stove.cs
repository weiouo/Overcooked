using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : BaseCounter
{
    private Ingredient ingredient;

    private void Update()
    {
        if (HasKitchenObject())
        {
            ingredient.Panfried();
        }
    }
    public override void Interact(Player player)
    {
        //鍋子沒東西
        if (!HasKitchenObject())
        {
            //玩家有東西 & 該東西是食材
            if (player.HasKitchenObject() & player.GetKitchenObject() is Ingredient)
            {
                //獲取食材
                ingredient = player.GetKitchenObject() as Ingredient;
                //該東西可煎
                if (ingredient.CanPanfried())
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
                else
                {
                    ingredient = null;
                }
            }
        }
        //鍋子有東西
        else
        {
            //玩家沒東西
            if (!player.HasKitchenObject()&& !ingredient.IsProcessFinished())
            {
                //拿食材
                ingredient = null;
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            else if (player.GetKitchenObject() is Plate && ingredient.IsProcessFinished())
            {
                //拿盤子裝食材
                Plate plate = player.GetKitchenObject() as Plate;
                Ingredient ingredient = GetKitchenObject() as Ingredient;
                if (plate.AddIngredient(ingredient))
                {
                    GetKitchenObject().DestroySelf();
                }
            }
        }
    }
}
