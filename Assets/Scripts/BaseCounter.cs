using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform countertop;
    private KitchenObject KitchenObject;
    public virtual void Interact(Player player)
    {
        Debug.LogError("Basecounter interact!");
    }
    //用basecounter連結counter和clearcounter的Interact功能
    //override去執行兩者之一的Interact
    public Transform countertransform()
    {
        return countertop;
    }
    public void SetKichenObject(KitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }
    public KitchenObject ReturnKitchenObject()
    {
        return KitchenObject;
    }
    public bool HasKitchenObject()
    {
        return this.KitchenObject != null;
    }
}
