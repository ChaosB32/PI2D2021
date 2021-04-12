using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject ItemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = ItemIcon.GetComponent<RectTransform>();
        itemIconImage = ItemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if(ItemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.instance.SpawnItem(
                        worldPosition,
                        itemSlot.item,
                        itemSlot.count
                        );

                    itemSlot.Clear();
                    ItemIcon.SetActive(false);
                }
            }
            
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            ItemIcon.SetActive(false);
        }
        else
        {
            ItemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
