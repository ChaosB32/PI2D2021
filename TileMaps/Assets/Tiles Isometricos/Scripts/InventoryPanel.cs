using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{

    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);
        Show();
        
    }
    public override void OnClickShop(int id)
    {
        GameManager.instance.dragAndDropController.OnClickShop(inventory.slots[id]);
        Show();
    }
   

}
