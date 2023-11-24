using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    [SerializeField] private int countdownTime = 5;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject countdownUI;
    [SerializeField] private GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        countdownUI.SetActive(true);
        gameUI.SetActive(false);
        InvokeRepeating("timer", 1, 1);
    }
    public void timer()
    {
        countdownTime--;
        timeText.text = countdownTime + " ";
        if (countdownTime == 0)
        {
            CancelInvoke("timer");
            countdownUI.SetActive(false);
            gameUI.SetActive(true);
        }
    }

}
