using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct IngredientSO_GameObject 
    {
        public IngredientSO IngredientSO;
        public GameObject GameObject;
    }

    [SerializeField] private Plate plate;
    [SerializeField] private List<IngredientSO_GameObject> IngredientSOGameObjectsList;
    private void Start()
    {
        plate.OnIngredientAdd += Plate_OnIngredientAdd;
        plate.IngredientClear += Plate_IngredientClear;
        foreach (IngredientSO_GameObject ingredientSO_GameObject in IngredientSOGameObjectsList)
        {
            ingredientSO_GameObject.GameObject.SetActive(false);
        }
    }

    private void Plate_IngredientClear(object sender, Plate.IngredientClearEventArgs e)
    {
        foreach (IngredientSO_GameObject ingredientSO_GameObject in IngredientSOGameObjectsList)
        {
            ingredientSO_GameObject.GameObject.SetActive(false);
        }
    }

    private void Plate_OnIngredientAdd(object sender, Plate.OnIngredientAddEventArgs e)
    {
       foreach (IngredientSO_GameObject ingredientSO_GameObject in IngredientSOGameObjectsList)
        {
            if (ingredientSO_GameObject.IngredientSO == e.ingredientSO)
            {
                ingredientSO_GameObject.GameObject.SetActive(true);
            }
        }
    }
}
