using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateIconSingle : MonoBehaviour
{
    [SerializeField] private Image image; 
    public void GetKitchenObjectIcon(IngredientSO ingredientSO)
    {
        image.sprite = ingredientSO.sprite;
    }
}
