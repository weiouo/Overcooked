using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : KitchenObject
{
    [SerializeField] private List<Mesh> cuttingMeshes;
    [SerializeField] private List<Mesh> panfriedMeshes;
    private bool needCut;
}
