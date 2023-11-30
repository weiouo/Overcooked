using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]//可以生成kitchenObject的定義
public class KichenObjectSO : ScriptableObject
{
    public Transform prefab;//指物件
    public Sprite sprite;//指圖像
    public string objectname;//物件名稱

}
