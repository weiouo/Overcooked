using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlateCounter : ClearCounter
{
    [SerializeField] private GameObject prefab;
    private void Start()
    {
        Plate plate = Instantiate(prefab).GetComponent<Plate>();
        plate.SetKitchenObjectParent(this);
    }
}
