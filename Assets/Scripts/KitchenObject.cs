using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KichenObjectSO kichenObjectSO;
    private IKitchenObjectParent KitchenObjectParent;

    public void SetKitchenObjectParent(IKitchenObjectParent _KitchenObjectParent)
    {
        //先清空Parent東西資料
        if (KitchenObjectParent != null)
        {
            KitchenObjectParent.ClearKitchenObject();
        }

        KitchenObjectParent = _KitchenObjectParent;
        //Parent有東西
        if (KitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Already had KitchenObject");
        }
        //Parent沒東西
        else
        {
            //給Parent東西
            KitchenObjectParent.SetKitchenObject(this);
            transform.parent = KitchenObjectParent.GetPoint();//更改KitchenObject的父物件 = 哪張桌子
            transform.localPosition = Vector3.zero;
        }
    }
}
