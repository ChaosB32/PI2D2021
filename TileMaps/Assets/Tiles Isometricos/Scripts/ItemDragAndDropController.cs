using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] ItemSlot shopSlot;
    [SerializeField] GameObject ItemIcon;
   
    RectTransform iconTransform;
    Image itemIconImage;

    public int coins;
    public TMP_Text coinUI;

    //tentativa pontuacao
    public static ItemDragAndDropController instance;

    public GameObject loja;

    [SerializeField] AudioClip sfxvender;


    private void Start()
    {
        instance = this;
        

        itemSlot = new ItemSlot();
        iconTransform = ItemIcon.GetComponent<RectTransform>();
        itemIconImage = ItemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if(ItemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;
            //vender na loja
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == true && loja.activeInHierarchy == true)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    AddCoins(itemSlot.item.SellPrice);
                    itemSlot.count --;
                    AudioManager.instance.Play(sfxvender);
                    if (itemSlot.count <= 0)
                    {
                        AudioManager.instance.Play(sfxvender);
                        itemSlot.Clear();
                        ItemIcon.SetActive(false);
                    }

                }
            }
            // jogar item fora
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
                    RemoveCoins(1);
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
    internal void OnClickShop(ItemSlot shopSlot)
    {
        if (this.shopSlot.item == null)
        {
            this.shopSlot.Copy(shopSlot);
            shopSlot.Clear();
        }
        else
        {
            Item item = shopSlot.item;
            int count = shopSlot.count;

            shopSlot.Copy(this.shopSlot);
            this.shopSlot.Set(item, count);
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
    public void AddCoins(float value)
    {
        coins+= Convert.ToInt32(value);
        coinUI.text = "x "+coins.ToString();

        //PlayerPrefs.SetInt("Pontuação", coins);
        //PlayerPrefs.Save();
    }
    public void RemoveCoins(float value)
    {

        coins -= Convert.ToInt32(value);
        coinUI.text = "x "+coins.ToString();

        //PlayerPrefs.SetInt("Pontuação", coins);
        //PlayerPrefs.Save();
    }
    
}
