using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//上面放一個東西:一般檯子的變體
public class InitialCounter : ClearCounter
{
    [SerializeField] private GameObject prefab;
    private void Start()
    {
        KitchenObject kitchenObject = Instantiate(prefab).GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(this);
    }
}
