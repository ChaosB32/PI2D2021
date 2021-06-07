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
    public CropsManager cropsManager;

    public GameObject questWindow;
    public Text description;

    public Text AmountTxt;

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
        crafting.quest = this;
        shopping.quest = this;
        cropsManager.quest = this;

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
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 2:
                SetActiveQuest(2);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 3:
                SetActiveQuest(3);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 4:
                SetActiveQuest(4);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 5:
                SetActiveQuest(5);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 6:
                SetActiveQuest(6);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 7:
                SetActiveQuest(7);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 8:
                SetActiveQuest(8);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 9:
                SetActiveQuest(9);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            case 10:
                SetActiveQuest(10);
                OpenQuestWindow();
                quest.goal.UpdateTxt();
                AmountTxt.gameObject.SetActive(true);
                break;

            default:
                SetActiveQuest(11);
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
