using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quests
{
    public bool isActive;

    public string description;

    public QuestGoals goal;

    public void Complete()
    {
        isActive = false;
        
        Debug.Log(description + "completo!!!");
    }

}
