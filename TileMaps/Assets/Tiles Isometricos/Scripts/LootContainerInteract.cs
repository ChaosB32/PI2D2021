using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject bauFechado;
    [SerializeField] GameObject bauAberto;
    [SerializeField] bool opened;
    public override void Interact(Character character)
    {
        if(opened == false)
        {
            opened = true;
            bauFechado.SetActive(false);
            bauAberto.SetActive(true);
        }
    }
}
