using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultUI : MonoBehaviour
{
    [SerializeField] private GameObject successfulUI;
    [SerializeField] private GameObject unsuccessfulUI;
    [SerializeField] private Animator successAnimator;
    [SerializeField] private Animator unsuccessAnimator;
    private const string SetOnSuccess = "SetOnSuccess";
    private const string SetOnUnsuccess = "SetOnUnsuccess";

    private void Start()
    {
        ServingManager.Instance.RecipeComplete += CompleteVisual;
        ServingManager.Instance.RecipeUncomplete += UncompleteVisual;
        successfulUI.SetActive(false);
        unsuccessfulUI.SetActive(false);
    }
    private void CompleteVisual(object sender, System.EventArgs e)
    {
        successfulUI.SetActive(true);
        successAnimator.SetTrigger(SetOnSuccess);
    }
    private void UncompleteVisual(object sender, System.EventArgs e)
    {
        unsuccessfulUI.SetActive(true);
        unsuccessAnimator.SetTrigger(SetOnUnsuccess);
    }
}
