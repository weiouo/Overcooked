using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//紀錄每個食材的狀態
public class Ingredient : KitchenObject
{
    [SerializeField] private IngredientSO ingredientSO;
    [SerializeField] private GameObject ProgressUI;
    [SerializeField] private Image colorPart;
    //切
    private bool needCut;
    private int maxCutCount = 10;
    private int cutCount = 0;
    //煎
    private bool needPanfried;
    private float maxPanfriedTime = 5.0f;
    private float panfriedTime = 0f;

    private MeshFilter ingredientMeshFilter;
    private bool isFinished = false;    // =true=>狀態對
    private void Start()
    {
        needCut = ingredientSO.cuttingMeshes.Count != 0;
        needPanfried = ingredientSO.panfriedMeshes.Count != 0;
        ingredientMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        isFinished = !needCut && !needPanfried;
        //UI
        ProgressUI.SetActive(false);
        colorPart.fillAmount = 0f;
    }
    public IngredientSO GetIngredientSO()
    {
        return ingredientSO;
    }
    public bool CanCut()
    {
        return needCut;
    }
    public bool CanPanfried()
    {
        //切好且需要煎
        return !needCut && needPanfried;
    }
    public bool IsProcessFinished()
    {
        return isFinished;
    }
    //紀錄切的次數
    public void Cut()
    {
        cutCount++;
        colorPart.fillAmount = (float)cutCount / maxCutCount;
        //切好
        if (cutCount >= maxCutCount)
        {
            ProgressUI.SetActive(false);
            needCut = false;
            isFinished = !needCut && !needPanfried;
            ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[2];
        }
        //切到一半
        else if (cutCount >= maxCutCount / 2)
        {
            ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[1];
        }
        //還沒切
        else
        {
            ProgressUI.SetActive(true);
            ingredientMeshFilter.mesh = ingredientSO.cuttingMeshes[0];
        }
    }
    //紀錄煎的秒數
    public void Panfried()
    {
        panfriedTime += Time.deltaTime;
        colorPart.fillAmount = panfriedTime / maxPanfriedTime;
        //焦
        if (panfriedTime >= 2 * maxPanfriedTime)
        {
            needPanfried = true;
            isFinished = !needCut && !needPanfried;
            ingredientMeshFilter.mesh  = ingredientSO.panfriedMeshes[2];
        }
        //熟
        else if (panfriedTime >= maxPanfriedTime)
        {
            ProgressUI.SetActive(false);
            needPanfried = false;
            isFinished = !needCut && !needPanfried;
            ingredientMeshFilter.mesh = ingredientSO.panfriedMeshes[1];
        }
        //生
        else
        {
            ProgressUI.SetActive(true);
            ingredientMeshFilter.mesh = ingredientSO.panfriedMeshes[0];
        }
    }
    //紀錄是否完成
}
