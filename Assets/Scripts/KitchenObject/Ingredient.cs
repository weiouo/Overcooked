using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    private int cutCount = 0;
    private float panFriedTime = 0f;
    private bool isFinished;
    //紀錄切的次數
    //紀錄煎的秒數
    //紀錄是否完成
}
