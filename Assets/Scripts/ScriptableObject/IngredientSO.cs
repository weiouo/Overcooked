using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class IngredientSO : KichenObjectSO
{
    public List<Mesh> cuttingMeshes;
    private bool needCut;
    public List<Mesh> panfriedMeshes;
    private bool needPanfried;
    public IngredientSO(List<Mesh> cuttingMeshes, List<Mesh> panfriedMeshes)
    {
        needCut = cuttingMeshes.Count != 0;
        needPanfried = panfriedMeshes.Count != 0;
    }
}
