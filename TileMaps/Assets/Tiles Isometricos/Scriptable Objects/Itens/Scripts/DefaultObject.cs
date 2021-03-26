using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Itens/Default")]
public class DefaultObject : ItemObject
{
    public float sellPrice;
    public float buyPrice;

    public void Awake()
    {
        type = ItemType.Default;
    }
}
