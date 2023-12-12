using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : BaseCounter
{
    private Ingredient ingredient;
    [SerializeField] private GameObject prefab;
    private void Start()
    {
        KitchenObject kitchenObject = Instantiate(prefab).GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(this);
    }
    private void Update()
    {
        if (GetKitchenObject() is Pan)
        {
            Pan pan = GetKitchenObject() as Pan;
            Ingredient ingredient = pan.GetKitchenObject() as Ingredient;
            if (pan.HasKitchenObject())
            {
                ingredient.Panfried();
            }
        }
    }
    public override void Interact(Player player)
    {
        if (HasKitchenObject())
        {
            Pan pan = GetKitchenObject() as Pan;
            if (!pan.HasKitchenObject())
            {
                if (player.HasKitchenObject() & player.GetKitchenObject() is Ingredient)
                {
                    //獲取食材
                    ingredient = player.GetKitchenObject() as Ingredient;
                    //該東西可煎
                    if (ingredient.CanPanfried())
                    {
                        player.GetKitchenObject().SetKitchenObjectParent(pan);
                    }
                    else
                    {
                        ingredient = null;
                    }
                }
                else if (!player.HasKitchenObject())
                {
                    pan.SetKitchenObjectParent(player);
                }
            }
            else
            {
                //玩家沒東西
                if (!player.HasKitchenObject())
                {
                    pan.SetKitchenObjectParent(player);
                }
                else if (player.GetKitchenObject() is Plate && ingredient.IsProcessFinished())
                {
                    //拿盤子裝食材
                    Plate plate = player.GetKitchenObject() as Plate;
                    Ingredient ingredient = pan.GetKitchenObject() as Ingredient;
                    if (plate.AddIngredient(ingredient))
                    {
                        pan.GetKitchenObject().DestroySelf();
                    }
                }
            }
        }
        else
        {
            if (player.GetKitchenObject() is Pan)
            {
                Pan pan = player.GetKitchenObject() as Pan;
                pan.SetKitchenObjectParent(this);
            }
        }
    }
}
