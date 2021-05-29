using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;

    [SerializeField] AudioClip sfxPegar;

    //quests
    //public Quests quest;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {

        this.item = item;
        this.count = count;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }
    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime);
        if (distance < 0.1f)
        {

            // mover isso para um controller especifico
            if (GameManager.instance.inventoryContainer!= null)
            {
                GameManager.instance.inventoryContainer.Add(item,count);

            }
            else
            {
                Debug.LogWarning("No inventory container in gameManager");
            }
            
            AudioManager.instance.Play(sfxPegar);
            /*
            if (quest.isActive)
            {
                quest.goal.ItemGathered();
                if (quest.goal.IsReached())
                {
                    quest.Complete();
                }
            }*/
            Destroy(gameObject);
            
        }
    }
}
