using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerController controller;
    private Heals heals;
    void Start()
    {
        controller = GetComponent<PlayerController>();
        heals = GetComponent<Heals>();

    }
    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();

    }
    public void UnEquip()
    {
        if (curEquip != null)
        {Destroy(curEquip.gameObject);
            curEquip = null;

        }
    }
}
