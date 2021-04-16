using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerController character;
    Rigidbody2D rgbd2D;
    ToolBarController toolBarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] ToolAction onTilePickUp;


    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<PlayerController>();
        rgbd2D = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();
    }
    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);

    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    
    private void Marker()
    {
        
        markerManager.markedCellPosition = selectedTilePosition;
    }
    private bool UseToolWorld()
    {
        Vector2 position = rgbd2D.position * offsetDistance;

        Item item = toolBarController.GetItem;
        if(item == null) { return false; }
        if(item.onAction == null) { return false; }

        bool complete = item.onAction.OnApply(position);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }
        }

        return complete;
    }

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            Item item = toolBarController.GetItem;
            if(item == null) {
                PickUpTile();
                return;
            }
            if (item.onTileMapAction == null) { return; }

            //colocar animacao aqui

            bool complete = item.onTileMapAction.OnApplyToTileMap(
                selectedTilePosition,tileMapReadController,
                item);


            if(complete == true)
            {
                if(item.onItemUsed!= null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }
    private void PickUpTile()
    {
        if(onTilePickUp == null) { return; }

        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
    }

}
