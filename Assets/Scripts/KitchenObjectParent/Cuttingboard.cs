using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttingboard : BaseCounter
{
    [SerializeField] private List<IngredientSO> CanCutIngredientSO;
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
                ingredient = (Ingredient)player.GetKitchenObject();
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
        }
    }
    public override void Cut()
    {
        //有食材才能切
        if (ingredient != null)
        {
            ingredient.Cut();
        }
    }
}
