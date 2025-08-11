using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
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
        dropPosition = PlayerManager.Instance.Player.dropPosition;  

        controller.inventory += Toggle;
        PlayerManager.Instance.Player.addItem += AddItem;

        //controller.inventory.GetInvocationList();
        //foreach()

        inventoryWindow.SetActive(false);
        slots = new ItemSlot[slotPanel.childCount];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;
            slots[i].inventory = this;
        }
        ClearSelectedItemWindow();
    }
    void Update()
    {

    }
    void ClearSelectedItemWindow()
    {
        selectedItem = null;
        selectedItemIndex = -1;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;
        useButton.SetActive(false);
        equipButton.SetActive(false);
        unequipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void Toggle()
    {
        if (IsOpen())
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }
    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    void AddItem()
    {
        ItemData data = PlayerManager.Instance.Player.itemData;

        
        if (data.canStack)
        {
            ItemSlot slot = GetItemStack(data);
            if(slot != null)
            {
                slot.quantity++;
                UpdateUI();
                PlayerManager.Instance.Player.itemData = null;
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();
        if(emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            UpdateUI();
            PlayerManager.Instance.Player.itemData = null;
            return;
        }

        ThrowItem(data);
        PlayerManager.Instance.Player.itemData = null;

    }
  void UpdateUI()
    {
        for(int i =0; i < slots.Length; i++)
        {
            if (slots[i] != null) 
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
    ItemSlot GetItemStack(ItemData data)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == data && slots[i].quantity < data.maxStackAmount)
            {
                return slots[i];
            }
        }
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for(int i =0; i <slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }
    void ThrowItem(ItemData data)
    {
        Instantiate(data.dropPrefab,dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360))
    }
}
