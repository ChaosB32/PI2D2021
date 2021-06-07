using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quests
{
    public bool isActive;

    public bool isComplete = false;

    public string description;

    public Item itemtype;

    public QuestGoals goal;

    //sfx
    [SerializeField] AudioClip sfxCompleted;

    public void Complete()
    {
        isActive = false;
        isComplete = true;
        Debug.Log(description + "completo!!!");
        goal.AmountTxt.gameObject.SetActive(false);
        AudioManager.instance.Play(sfxCompleted);
        PlayerPrefs.SetInt("questIndex", PlayerPrefs.GetInt("questIndex") + 1); //aumenta questIndex por 1 cada vez que completa uma quest.
    }

}
