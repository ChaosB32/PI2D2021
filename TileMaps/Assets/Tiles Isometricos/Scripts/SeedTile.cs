using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tool action/Seed Tile")]
public class SeedTile : ToolAction
{
    [SerializeField] AudioClip sfxSeed;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController
        , Item item)
    {
        if(tileMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }
        tileMapReadController.cropsManager.Seed(gridPosition,item.crop);
        AudioManager.instance.Play(sfxSeed);
        return true;
    }

    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
