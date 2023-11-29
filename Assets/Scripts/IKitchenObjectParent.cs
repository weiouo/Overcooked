using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform countertransform();
    public void SetKichenObject(KitchenObject kitchenObject);
    public void ClearKitchenObject();
    public KitchenObject ReturnKitchenObject();
    public bool HasKitchenObject();
}
