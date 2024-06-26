using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] AudioClip sfxCraft;
    [SerializeField] AudioClip sfxErro;

    public QuestGiver quest;
    public void Craft(CraftingRecipe recipe)
    {
        if(inventory.CheckFreeSpace() == false)
        {
            Debug.Log("Sem espa�o para o item apos o craft");
            return;
        }
        
        for(int i=0; i < recipe.elements.Count; i++)
        {
            if (inventory.CheckItem(recipe.elements[i])==false)
            {
               
                Debug.Log("Os componentes da receita nao estao no invent�rio");
                AudioManager.instance.Play(sfxErro);
                return;
            }
        }

        for(int i = 0; i < recipe.elements.Count; i++)
        {
            inventory.Remove(recipe.elements[i].item, recipe.elements[i].count);
        }

        inventory.Add(recipe.output.item, recipe.output.count);
        
        AudioManager.instance.Play(sfxCraft);
        
        if (quest.quest.isActive && recipe.output.item == quest.quest.itemtype)
        {
            Debug.Log("qualquer coisa " + quest.quest.goal.currentAmount);
            quest.quest.goal.ItemCrafted();
            if (quest.quest.goal.IsReached())
            {
                quest.quest.Complete();
            }
        }
    }
}
