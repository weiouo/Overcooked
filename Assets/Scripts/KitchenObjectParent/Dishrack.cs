using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishrack : BaseCounter
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int plateCount;
    [SerializeField] private float generateTime;
    private GameObject plate;
    private int count;
    private float time;
    public void Update()
    {
        time += Time.deltaTime;
        if (time >= generateTime)
        {
            time = 0;
            if (count < plateCount)
            {
                GeneratePlateVisual(count);
                count++;
            }
            else
            {
                Debug.Log("full");
            }
        }
    }
    private void GeneratePlateVisual(int plateIndex)
    {
        Transform startPoint = GetPoint();
        Vector3 offset = new Vector3(-0.25f * plateIndex, 0, 0);
        plate = Instantiate(prefab, startPoint.position + offset, Quaternion.Euler(0, 0, 90));
    }
    public override void Interact(Player player)
    {
        //玩家沒東西
        if (!player.HasKitchenObject() && count != 0)
        {
            count--;
            Destroy(plate);
            //給玩家東西
            KitchenObject kitchenObject = Instantiate(prefab).GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
        }
    }
}
