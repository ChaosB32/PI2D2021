using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Itens/Equipment")]
public class EquipmentObject : ItemObject
{
    public float durability;
    public float price;

    public void Awake()
    {
        type = ItemType.Equipamentos;
    }
}
