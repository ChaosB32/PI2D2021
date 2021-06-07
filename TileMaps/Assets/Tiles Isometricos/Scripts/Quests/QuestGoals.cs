using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoals
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemGathered()
    {
        if(goalType == GoalType.Gathering)
        {
            currentAmount++;
            Debug.Log(currentAmount);
        }
    }
    public void ItemCrafted()
    {
        if (goalType == GoalType.Crafting)
        {
            currentAmount++;
        }
    }
    public void ItemBuyed()
    {
        if (goalType == GoalType.Buying)
        {
            currentAmount++;
        }
    }
    public void ItemSelled()
    {
        if (goalType == GoalType.Selling)
        {
            currentAmount++;
        }
    }

}

public enum GoalType
{
    Gathering,
    Crafting,
    Buying,
    Selling,
}

