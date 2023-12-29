using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position;
    }
    private void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, offset.y, Player.transform.position.z + offset.z);
    }
}
