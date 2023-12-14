using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUIController: MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI coinText;
    
    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }
}
