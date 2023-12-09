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
