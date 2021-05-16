using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text priceText;
    [SerializeField] Image highLight;

    //loja
    [SerializeField] int buyPrice;
    public Item item;
    [SerializeField] AudioClip sfxComprar;
    [SerializeField] AudioClip sfxErro;

    int myIndex;

    public void Start()
    {
        if(item!=null)
        {
            icon.sprite = item.icon;
            priceText.text = buyPrice.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetIndex(int index)
    {
        myIndex = index;

    }

    public void PurchaseItem()
    {
        Debug.Log("Item da compra");
        if (EnoughCoins())
        {
            Debug.Log("Moedas suficientes para comprar" + item);
            //falta add ao inventario
            ItemDragAndDropController.instance.RemoveCoins(buyPrice);
            if (GameManager.instance.inventoryContainer != null)
            {
                AudioManager.instance.Play(sfxComprar);
                GameManager.instance.inventoryContainer.Add(item);
            }
        }
        else
        {
            Debug.Log("Precisa de mais moedas para comprar" + item);
            AudioManager.instance.Play(sfxErro);
        }
    }

    public bool EnoughCoins()
    {
        if(ItemDragAndDropController.instance.coins - buyPrice >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
