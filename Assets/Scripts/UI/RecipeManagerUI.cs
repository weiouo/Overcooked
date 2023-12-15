using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipetemplate;

    private void Awake()
    {
        recipetemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        ServingManager.Instance.RecipeSpawn += RecipeSpawnVisual;
        ServingManager.Instance.RecipeComplete += RecipeCompleteVisual;
        Visual();
    }

    private void RecipeSpawnVisual(object sender, System.EventArgs e)
    {
        Visual();
    }

    private void RecipeCompleteVisual(object sender, System.EventArgs e) 
    {
        Visual();
    }

    private void Visual()
    {
        foreach(Transform transform in container)
        {
            if(transform == recipetemplate)
            {
                continue;
            }
            Destroy(transform.gameObject);
        }

        foreach(RecipeSO recipe in ServingManager.Instance.GetWaitRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipetemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<RecipeManagerSingleUI>().RecipeSOSet(recipe);
        }
    }
}
