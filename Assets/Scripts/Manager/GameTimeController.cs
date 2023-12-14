using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameTimeController : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelDataSO;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private UnityEvent timesUp;
    private float time;
    private void Start()
    {
        time = levelDataSO.levelTime;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        SetTimeText(time);
        if (time <= 0 )
        {
            timesUp.Invoke();
        }
    }
    public void SetTimeText(float time)
    {
        timeText.text = Mathf.Ceil(time).ToString();
    }
}
