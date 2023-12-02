using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()]//可以生成kitchenObject的定義
public class KitchenObjectSO : ScriptableObject
{
    public string objectName;//物件名稱
    public Transform prefab;//指物件
    public Sprite sprite;//指圖像
}
