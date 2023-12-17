using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//紀錄每個食材的狀態
public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    [SerializeField] private GameObject progressUI;
    [SerializeField] private GameObject waringPart;
    private MeshFilter ingredientMeshFilter;
    private Progress progress;
    //切
    private bool needCut;
    private int maxCutCount = 10;
    private int cutCount = 0;
    //煎
    private bool needPanfried;
    private float maxPanfriedTime = 5.0f;
    private float panfriedTime = 0f;

    private void Start()
    {
        progressUI.SetActive(false);
        needCut = ingredientSO.cuttingMeshes.Count != 0;
        needPanfried = ingredientSO.panfriedMeshes.Count != 0;
        ingredientMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        progress = progressUI.GetComponent<Progress>();
    }
    //紀錄切的次數
    public void Cut()
    {
        progressUI.SetActive(true);
        progress.SetColorFillAmount((float)cutCount / maxCutCount);
        cutCount++;
        //切好
        if (cutCount >= maxCutCount)
        {
            progressUI.SetActive(false);
            needCut = false;
            SetMesh(ingredientSO.cuttingMeshes[2]);
        }
        //切到一半
        else if (cutCount >= maxCutCount / 2)
        {
            SetMesh(ingredientSO.cuttingMeshes[1]);
        }
        //還沒切
        else
        {
            SetMesh(ingredientSO.cuttingMeshes[0]);
        }
    }
    //紀錄煎的秒數
    public void Panfried()
    {
        progressUI.SetActive(true);
        progress.SetColorFillAmount((panfriedTime / maxPanfriedTime) % 1.0f);
        panfriedTime += Time.deltaTime;
        //焦
        if (panfriedTime >= 2 * maxPanfriedTime)
        {
            progressUI.SetActive(false);
            needPanfried = true;
            SetMesh(ingredientSO.panfriedMeshes[2]);
        }
        //熟
        else if (panfriedTime > maxPanfriedTime)
        {
            progress.SwitchToWarnColor();
            needPanfried = false;
            SetMesh(ingredientSO.panfriedMeshes[1]);
            if (panfriedTime > maxPanfriedTime + 2.5f)
            {
                waringPart.SetActive(true);
            }
        }
        //生
        else
        {
            SetMesh(ingredientSO.panfriedMeshes[0]);
        }
    }
    public IngredientSO GetIngredientSO()
    {
        return ingredientSO;
    }
    public bool CanCut()
    {
        //需要切
        return needCut;
    }
    public bool CanPanfried()
    {
        //切好且需要煎
        return !needCut && needPanfried;
    }
    public bool IsComplete()
    {
        return !needCut && !needPanfried;
    }
    private void SetMesh(Mesh mesh)
    {
        ingredientMeshFilter.mesh = mesh;
    }
}
