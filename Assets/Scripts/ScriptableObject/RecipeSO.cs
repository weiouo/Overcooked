using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
//³æ¤@µæ³æ
public class RecipeSO : ScriptableObject
{
    public List<IngredientSO> ingredients;
    public string recipeName;
}
