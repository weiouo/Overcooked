using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] private BaseCounter counter;
    [SerializeField] private GameObject visualObject;
    private void Start()
    {
        Player.Instance.OnSelectedCounter += Player_OnSelectedCounter;
    }

    private void Player_OnSelectedCounter(object sender, Player.OnSelectedEventArgs e)
    {
        if (e.SelectedCounter == counter)
        {
            visualObject.SetActive(true);
        }
        else
        {
            visualObject.SetActive(false);
        }
    }
}
