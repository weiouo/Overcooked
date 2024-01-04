using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupMenu : MonoBehaviour
{
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject addPlayerText;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject startCamera;
    private bool isGameStart;
    private int playerNum;
    private void Start()
    {
        isGameStart = false;
        player2.SetActive(false);
        addPlayerText.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal_1") != 0 || Input.GetAxisRaw("Vertical_1") != 0)
        {
            isGameStart = true;
            PlayerPrefs.SetInt("PlayerNumber", playerNum);
            startCamera.GetComponent<Animation>().Play();
            addPlayerText.SetActive(false);
            startPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isGameStart)
        {
            player2.SetActive(!player2.activeSelf);
            addPlayerText.SetActive(!player2.activeSelf);
            playerNum = player2.activeSelf ? 2 : 1;
        }
    }
}
