using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelDataSO;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private List<TextMeshProUGUI> scores;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI ordersDelivered;
    [SerializeField] private TextMeshProUGUI ordersFailed;
    [SerializeField] private TextMeshProUGUI total;
    private int orderDeliveredNum;
    private int orderFailedNum;
    private int coin;
    // Start is called before the first frame update
    void Start()
    {
        orderDeliveredNum = 0;
        coin = 0;
        coinText.text = "$" + coin.ToString();
    }
    public void IncreaseOrder()
    {
        orderDeliveredNum++;
        IncreaseCoin(100);
    }
    public void IncreaseCoin(int orderCoin)
    {
        coin += orderCoin;
        coinText.text = "$" + coin.ToString();
    }
    public void SetupEndPanel()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            scores[i].text = levelDataSO.levelScores[i].ToString();
            if (coin < levelDataSO.levelScores[i])
            {
                stars[i].SetActive(false);
            }
        }
        ordersDelivered.text = "Orders Delivered x " + orderDeliveredNum.ToString();
        ordersFailed.text = "Orders Failed x " + orderFailedNum.ToString();
        total.text = "Total : $" + coin.ToString();
    }
}
