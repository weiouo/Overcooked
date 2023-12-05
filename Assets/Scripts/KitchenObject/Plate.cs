using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Plate : KitchenObject
{
    private List<Ingredient> ingredients;
    public void AddIngredient(Ingredient ingredient)
    {
        //同樣食材只能裝一次 && 是已完成的食材
        if (!ingredients.Contains(ingredient) && ingredient.IsProcessFinished())
        {
            ingredients.Add(ingredient);
        }
    }
    public void ClearIngredient()
    {
        ingredients.Clear();
    }
}
