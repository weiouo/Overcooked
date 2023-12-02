using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    private bool isFinished;
}
