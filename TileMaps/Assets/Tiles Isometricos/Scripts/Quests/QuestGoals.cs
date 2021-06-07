using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestGoals
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    // visual quests
    public Text AmountTxt;

    public void UpdateTxt()
    {
        AmountTxt.text = currentAmount.ToString() + "/"+ requiredAmount.ToString();
    }
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemGathered()
    {
        if(goalType == GoalType.Gathering)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            Debug.Log(currentAmount);
            UpdateTxt();
        }
    }
    public void ItemCrafted()
    {
        if (goalType == GoalType.Crafting)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            UpdateTxt();
        }
    }
    public void ItemBuyed()
    {
        if (goalType == GoalType.Buying)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            UpdateTxt();
        }
    }
    public void ItemSelled()
    {
        if (goalType == GoalType.Selling)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            UpdateTxt();
        }
    }
    public void ItemPlowed()
    {
        if (goalType == GoalType.Plowing)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            UpdateTxt();
        }
    }
    public void ItemPlanted()
    {
        if (goalType == GoalType.Planting)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            UpdateTxt();
        }
    }
    public void ItemHarvested()
    {
        if (goalType == GoalType.Harvesting)
        {
            AmountTxt.gameObject.SetActive(true);
            currentAmount++;
            UpdateTxt();
        }
    }
    public void Null()
    {
        if (goalType == GoalType.Harvesting)
        {
            AmountTxt.gameObject.SetActive(false);
        }
    }

}

public enum GoalType
{
    Gathering,
    Crafting,
    Buying,
    Selling,
    Plowing,
    Planting,
    Harvesting,
    Null,
}

