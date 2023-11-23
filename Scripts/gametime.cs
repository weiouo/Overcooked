using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gametime : MonoBehaviour
{
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI moneytext;
    public GameObject counting;
    public TextMeshProUGUI timeup;
    public GameObject moneyimage;
    public GameObject timeimage;
    public int time = 65,money = 0;
    // Start is called before the first frame update
    void Start()
    {
        timetext.text = time + " ";
        moneytext.text = "$ "+money + " ";
        InvokeRepeating("timer", 1, 1);
    }
    public void timer()
    {
        time--;
        timetext.text = time + " ";
        moneytext.text = "$ " + money + " ";
        if (time == 0)
        {
            CancelInvoke("timer");
            counting.SetActive(true);
            timeup.text = "Time Up !";
            moneyimage.SetActive(false);
            timeimage.SetActive(false);
        }
    }
}
