using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishrack : BaseCounter
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int plateCount;
    [SerializeField] private float generateTime;
    private List<GameObject> plates = new List<GameObject>();
    private GameObject plate;
    private int plateIndex = 0;
    private float time = 0f;
    public void Update()
    {
        time += Time.deltaTime;
        if (time >= generateTime)
        {
            time = 0;
            if (plateIndex < plateCount)
            {
                GeneratePlateVisual(plateIndex);
            }
        }
    }
    private void GeneratePlateVisual(int index)
    {
        Transform startPoint = GetPoint();
        Vector3 offset = new Vector3(0, 0, 0.2f * index);
        plate = Instantiate(prefab, transform);
        plate.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        plate.transform.localPosition =  startPoint.localPosition + offset;
        plate.transform.localRotation = Quaternion.Euler(90, 0, 0);
        plates.Add(plate);
        plateIndex++;
    }
    public override void Interact(Player player)
    {
        //玩家沒東西 && 有盤子
        if (!player.HasKitchenObject() && plateIndex != 0)
        {
            plateIndex--;
            plate = plates[plateIndex];
            plates.Remove(plate);
            //給玩家盤子
            plate.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
    }
}
