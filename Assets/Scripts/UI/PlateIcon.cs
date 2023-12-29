using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlateIcon : MonoBehaviour
{
    [SerializeField] private Plate plate;
    [SerializeField] private Transform Icon;

    private void Awake()
    {
        Icon.gameObject.SetActive(false);
    }

    void Start()
    {
        plate.OnIngredientAdd += Plate_OnIngredientAdded;
        plate.IngredientClear += Plate_IngredientClear;
    }

    private void Plate_IngredientClear(object sender, Plate.IngredientClearEventArgs e)
    {
        VisualIconUIClear();
    }

    private void Plate_OnIngredientAdded(object sender , Plate.OnIngredientAddEventArgs e) 
    {
        VisualIconUI();
    }

    private void VisualIconUI()
    {
        Ingredient ingredient = plate.GetIngredient();
        Transform icontransform = Instantiate(Icon, transform);
        icontransform.gameObject.SetActive(true);
        icontransform.GetComponent<PlateIconSingle>().GetKitchenObjectIcon(ingredient.GetIngredientSO()); 
    }
    private void VisualIconUIClear()
    {
        foreach(Transform Child in transform)
        {
           if (Child == Icon) { continue; }
            Destroy(Child.gameObject);
        }
    }
}
