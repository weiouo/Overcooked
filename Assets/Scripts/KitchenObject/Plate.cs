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
    public class IngredientClearEventArgs : EventArgs { }

    [SerializeField] private IngredientSO bun;
    private List<IngredientSO> ingredients;
    private Ingredient ingredient_return;
    public void Start()
    {
        ingredients = new List<IngredientSO>();
    }
    public bool AddIngredient(Ingredient ingredient)
    {
        if (!ingredients.Contains(ingredient.GetIngredientSO()) && ingredient.IsComplete())
        {
            if (ingredient.GetIngredientSO().objectName == "Bun")
            {
                ingredient_return = ingredient;
                ingredients.Add(ingredient.GetIngredientSO());
                OnIngredientAdd?.Invoke(this, new OnIngredientAddEventArgs
                {
                    ingredientSO = ingredient.GetIngredientSO()
                });
                return true;
            }
            else if (ingredients.Contains(bun))
            {
                ingredient_return = ingredient;
                ingredients.Add(ingredient.GetIngredientSO());
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
        return ingredient_return;
    }

    public List<IngredientSO> GetIngredientList()
    {
        return ingredients;
    } 
    public void ClearIngredient()
    {
        ingredients.Clear();
        IngredientClear?.Invoke(this, new IngredientClearEventArgs { });
    }
}
