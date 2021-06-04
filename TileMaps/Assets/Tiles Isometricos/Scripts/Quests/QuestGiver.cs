using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quests quest;

    public PickUpItem pickUpItem;
    //public Crafting crafting;

    public GameObject questWindow;
    public Text description;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        description.text = quest.description;
    }
    
    public void AcceptQuest()
    {
        //questWindow.SetActive(false);
        quest.isActive = true;
        pickUpItem.quest = this;
        //crafting.quest = quest;
    }
    private void Update()
    {
        if(quest.isActive == false)
        {
            questWindow.SetActive(false);
        }
    }

}
