using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] Slots;

    public GameObject inventoryWidth;
    public Transform slotPanel;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unequipButton;
    public GameObject dropButton;

    private int curEquipIndex;

    private PlayerController controller;
    private Heals heals;

    private void Start()
    {
        controller = PlayerManager.Instance.Player.playerController;
        heals = PlayerManager.Instance.Player.heals;
        //dropPosition = PlayerManager.Instance.Player.dropPosition;

        //controller.inventory += Toggle;
    }
}
