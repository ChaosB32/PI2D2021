using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyOrSell : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public void AddCoins()
    {
        coins++;
        coinUI.text = coins.ToString();
    }
}
