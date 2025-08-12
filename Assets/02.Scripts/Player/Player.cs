using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerController;
    public Heals heals;
    public Equipment equip;

    public ItemData itemData;
    public ItemObject itemObject;
    public Action addItem;

    public Transform dropPosition;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        playerController = GetComponent<PlayerController>();
        heals = GetComponent<Heals>();
        equip = GetComponent<Equipment>();
    }
}
