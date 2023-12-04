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
        //桌上沒東西
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
        }
    }
}
