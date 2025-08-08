using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerController;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        playerController = GetComponent<PlayerController>();
    }
}
