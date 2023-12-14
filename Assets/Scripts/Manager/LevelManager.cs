using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelDataSO;
    [SerializeField]  private InGameUIController inGameController;
    private float time;
    private int coin;
    // Start is called before the first frame update
    void Start()
    {
        time = levelDataSO.levelTime;
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
    }
}
