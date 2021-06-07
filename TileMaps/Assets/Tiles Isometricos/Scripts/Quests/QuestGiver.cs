using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{

    public List<Quests> questList;
    public Quests quest;

    public PickUpItem pickUpItem;
    public Crafting crafting;
    public ShopSlot shopping;

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
        crafting.quest = questList[2];
        shopping.quest = this;
    }
    private void Update()
    {
        if(quest.isActive == false)
        {
            questWindow.SetActive(false);
        }

        switch (PlayerPrefs.GetInt("questIndex"))
        {

            //Quest 1
            case 0:
                SetActiveQuest(0);
                OpenQuestWindow();
                break;

            case 1:
                SetActiveQuest(1);
                OpenQuestWindow();
                break;

            case 2:
                SetActiveQuest(2);
                OpenQuestWindow();
                break;

            case 3:
                SetActiveQuest(3);
                OpenQuestWindow();
                break;

            case 4:
                SetActiveQuest(4);
                OpenQuestWindow();
                break;

            case 5:
                SetActiveQuest(5);
                OpenQuestWindow();
                break;

            case 6:
                SetActiveQuest(6);
                OpenQuestWindow();
                break;

            case 7:
                SetActiveQuest(7);
                OpenQuestWindow();
                break;

            default:
                SetActiveQuest(0);
                OpenQuestWindow();
                break;
        }
    }
    public void SetActiveQuest(int num)
    {
        quest = questList[num]; //Coloca a quest ativa na quest atual;
        
        quest.isActive = true;
    }
}
