using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class IngredientSO : KichenObjectSO
{
    public string itemName;
    public GameObject ingredientPrefab;
    public Mesh ingredient;
    public Mesh ingredientChoped;
    public Mesh ingredientSliced;
}
