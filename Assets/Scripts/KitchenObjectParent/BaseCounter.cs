using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform topPoint;
    [SerializeField] private GameObject visualObject;
    private KitchenObject KitchenObject;

    //處理拿放
    public virtual void Interact(Player player){}
    //處理切
    public virtual void Cut(Player player){}

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
    public void HideVisualObject()
    {
        visualObject.SetActive(false);
    }
    public void ShowVisualObject()
    {
        visualObject.SetActive(true);
    }
}
