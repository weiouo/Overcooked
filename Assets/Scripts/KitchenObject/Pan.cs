using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : KitchenObject,IKitchenObjectParent
{
    [SerializeField] private Transform holdPoint;
    private KitchenObject KitchenObject;

    //©w¸qKitchenObjectParent¤¶­±
    public Transform GetPoint()
    {
        return holdPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }
    public KitchenObject GetKitchenObject()
    {
        return KitchenObject;
    }
    public bool HasKitchenObject()
    {
        return this.KitchenObject != null;
    }
}
