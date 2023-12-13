using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] private Image colorPart;
    [SerializeField] private Color warnColor;
    public void SetColorFillAmount(float percent)
    {
        colorPart.fillAmount = percent;
    }
    public void SwitchToWarnColor()
    {
        colorPart.color = new Color(warnColor.r, warnColor.g, warnColor.b);
    }
}
