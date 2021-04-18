using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreenController : ShopPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(shop.slots[id]);
        Show();
    }
}
