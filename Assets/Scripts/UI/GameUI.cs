using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private int time = 65, money = 0;
    [SerializeField] private TextMeshProUGUI timeup;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject counting;
    [SerializeField] private GameObject timeImage;
    [SerializeField] private GameObject moneyImage;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = time + " ";
        moneyText.text = "$ "+money + " ";
        InvokeRepeating("timer", 1, 1);
    }
    public void timer()
    {
        time--;
        timeText.text = time + " ";
        moneyText.text = "$ " + money + " ";
        if (time == 0)
        {
            CancelInvoke("timer");
            counting.SetActive(true);
            timeup.text = "Time Up !";
            moneyImage.SetActive(false);
            timeImage.SetActive(false);
        }
    }
}
