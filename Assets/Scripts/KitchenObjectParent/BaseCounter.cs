using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform topPoint;
    private KitchenObject KitchenObject;

    //用BaseCounter連結Crate和ClearCounter的Interact功能
    //override去執行兩者之一的Function
    public virtual void Interact(Player player){}

    //定義KitchenObjectParent介面
    public Transform GetPoint()
    {
        return topPoint;
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
