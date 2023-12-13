using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Plate : KitchenObject
{
    public event EventHandler <OnIngredientAddEventArgs> OnIngredientAdd;
    public event EventHandler<IngredientClearEventArgs> IngredientClear;
    public class OnIngredientAddEventArgs : EventArgs 
    { 
        public IngredientSO ingredientSO;
    }
    public class IngredientClearEventArgs : EventArgs {}
    private List<string> ingredients;
    private Ingredient ingredient_return;
    public void Start()
    {
        ingredients = new List<string>();
    }
    public bool AddIngredient(Ingredient ingredient)
    {
        //同樣食材只能裝一次 && 是已完成的食材
        if (!ingredients.Contains(ingredient.GetIngredientSO().objectName) && ingredient.IsComplete())
        {
            if (ingredient.GetIngredientSO().objectName == "Bun")
            {
                ingredient_return = ingredient;
                ingredients.Add(ingredient.GetIngredientSO().objectName);
                OnIngredientAdd?.Invoke(this, new OnIngredientAddEventArgs
                {
                    ingredientSO = ingredient.GetIngredientSO()
                });
                return true;
            }
            else if (ingredients.Contains("Bun"))
            {
                ingredient_return = ingredient;
                ingredients.Add(ingredient.GetIngredientSO().objectName);
                OnIngredientAdd?.Invoke(this, new OnIngredientAddEventArgs
                {
                    ingredientSO = ingredient.GetIngredientSO()
                });
                return true;
            }
        }
        return false;
    }

    public Ingredient GetIngredient()
    {
        ingredients.Clear();
        IngredientClear?.Invoke(this, new IngredientClearEventArgs {});
        return ingredient_return;
    }

    public List<string> GetIngredientList()
    {
        return ingredients;
    } 
    //public void ClearIngredient()
    //{
    //    ingredients.Clear(); 
    //}
}
