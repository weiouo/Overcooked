using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IngredientData", menuName = "IngredientData")]
public class Ingredient : ScriptableObject
{
    public string itemName;
    public GameObject ingredientPrefab;
    public Mesh ingredient;
    public Mesh ingredientChoped;
    public Mesh ingredientSliced;
}
