using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGame : MonoBehaviour
{
    [SerializeField] private GameObject player2;
    private void Start()
    {
        int playerNum = PlayerPrefs.GetInt("PlayerNumber", 0);
        if (playerNum == 2 )
        {
            player2.SetActive(true);
        }
    }
}
