using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeName;
    [SerializeField] private Transform IconContainer;
    [SerializeField] private Transform IconSingleIngredient;
    [SerializeField] private Transform IconFood;

    private void Awake()
    {
        IconSingleIngredient.gameObject.SetActive(false);
    }

    public void RecipeSOSet(RecipeSO recipeSO)
    {
        recipeName.text = recipeSO.recipeChineseName; //­n­^¤å + "\n(" + recipeSO.recipeName + ")";
        IconFood.GetComponent<Image>().sprite = recipeSO.RecipeFoodSprite;
        foreach(Transform transform in IconContainer)
        {
            if(transform == IconSingleIngredient)
            {
                continue;
            }
            Destroy(transform.gameObject);
        }

        foreach(IngredientSO ingredient in recipeSO.ingredients)
        {
            Transform Icon = Instantiate(IconSingleIngredient, IconContainer);
            Icon.GetComponent<Image>().sprite = ingredient.sprite;
            Icon.gameObject.SetActive(true);
        }
    }
}
