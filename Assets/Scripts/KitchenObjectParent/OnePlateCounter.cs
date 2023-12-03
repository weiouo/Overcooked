using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//上面放一個盤子:一般檯子的變體
public class OnePlateCounter : ClearCounter
{
    [SerializeField] private GameObject prefab;
    private void Start()
    {
        Plate plate = Instantiate(prefab).GetComponent<Plate>();
        plate.SetKitchenObjectParent(this);
    }
}
