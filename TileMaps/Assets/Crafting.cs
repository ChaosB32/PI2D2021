using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] AudioClip sfxCraft;
    [SerializeField] AudioClip sfxErro;

    //public Quests quest;
    public void Craft(CraftingRecipe recipe)
    {
        if(inventory.CheckFreeSpace() == false)
        {
            Debug.Log("Sem espaço para o item apos o craft");
            return;
        }
        
        for(int i=0; i < recipe.elements.Count; i++)
        {
            if (inventory.CheckItem(recipe.elements[i])==false)
            {
               
                Debug.Log("Os componentes da receita nao estao no inventário");
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
        
        /*if (quest.isActive)
        {
            quest.goal.ItemCrafted();
            if (quest.goal.IsReached())
            {
                quest.Complete();
            }
        }*/
    }
}
