using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//KitchenObjectParent¤¶­±
//KitchenObjectParent: Player,BaseCounter
public interface IKitchenObjectParent 
{
    public Transform GetPoint();
    public void SetKitchenObject(KitchenObject kitchenObject); 
    public void ClearKitchenObject();
    public KitchenObject GetKitchenObject();
    public bool HasKitchenObject();
}
