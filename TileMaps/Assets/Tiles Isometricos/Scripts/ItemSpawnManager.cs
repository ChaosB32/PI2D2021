using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;

    QuestGiver[] todasQuests;

    private void Awake()
    {
        instance = this;
        todasQuests = FindObjectsOfType<QuestGiver>();
    }

    [SerializeField] GameObject pickUpItemPrefab;

    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickUpItem>().Set(item, count);
        foreach(QuestGiver quest in todasQuests)
        {
            if(quest.pickUpItem == pickUpItemPrefab)
            {
                o.GetComponent<PickUpItem>().quest=quest;
            }
        }
    }
}
