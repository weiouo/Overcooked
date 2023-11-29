using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KichenObjectSO KichenObjectSO;
    private IKitchenObjectParent KitchenObjectParent;

    public KichenObjectSO KichenObject_return(IKitchenObjectParent KitchenObjectParent)
    {
        return KichenObjectSO;
    }
    //確認KitchenObject位置(位於哪個桌子上)
    public void SetKitchenObjectParent(IKitchenObjectParent KitchenObjectParent)
    {
        if (this.KitchenObjectParent != null)
        {
            this.KitchenObjectParent.ClearKitchenObject();
        }
        this.KitchenObjectParent = KitchenObjectParent;
        if (KitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Already had KitchenObject");
        }
        else
        {
            KitchenObjectParent.SetKichenObject(this);
            transform.parent = KitchenObjectParent.countertransform();//更改KitchenObject的父物件 =哪張桌子
            transform.localPosition = Vector3.zero;
        }
    }
    public IKitchenObjectParent ReturnCounter()
    {
        return KitchenObjectParent;
    }
}
