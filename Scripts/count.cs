using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class count : MonoBehaviour
{
    public TextMeshProUGUI timetext;
    public int num = 5;
    public GameObject pausemenu;
    public GameObject counting;
    public GameObject money;
    public GameObject time;
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
        money.SetActive(false);
        time.SetActive(false);
        counting.SetActive(true);
        InvokeRepeating("timer", 1, 1);
    }
    public void timer()
    {
        num--;
        timetext.text = num + " ";
        if (num == 0)
        {
            CancelInvoke("timer");
            counting.SetActive(false);
            money.SetActive(true);
            time.SetActive(true);
        }
    }

}
