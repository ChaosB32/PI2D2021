using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("OnApply n�o est� implementado");
        return true;
    }

    public virtual bool OnApplyToTileMap(Vector3Int gridPosition,TileMapReadController tileMapReadController
        ,Item item)
    {

        Debug.LogWarning("OnApplyToTileMap n�o est� implementado");
        return true;
    }

    public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        
    }
}
