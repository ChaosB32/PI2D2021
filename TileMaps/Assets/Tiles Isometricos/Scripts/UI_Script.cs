using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public int coins = 1;
    public TMP_Text coinUI;
    public ShopObject shop;
    public InventoryObject inventory;

    void Start()
    {
        coinUI.text = coins.ToString();
        this.coinUI = GameObject.FindObjectOfType<TextMeshProUGUI>();
    }
    private void Update()
    {

    }
    public void AddCoins()
    {
        coins++;
        coinUI.text = coins.ToString();
    }
    public void RemoveCoins()
    {
        
        coins--;
        coinUI.text = coins.ToString();
    }
}
