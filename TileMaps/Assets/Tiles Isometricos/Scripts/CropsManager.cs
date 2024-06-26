using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropTile
{
    public int growTimer;
    public int growStage;
    public Crop crop;
    public SpriteRenderer renderer;
    public float damage; //plantacao
    public Vector3Int position;


    public bool Complete
    {
        get
        {   
            if(crop == null) { return false; }
            return growTimer>= crop.timeToGrow;
        }
    }

    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
        damage = 0;
    }
}

public class CropsManager : TimeAgent
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;

    //sfx
    [SerializeField] AudioClip sfxCompleted;
    [SerializeField] AudioClip sfxPlow;

    //visual
    [SerializeField] GameObject readyMessage;

    [SerializeField] Tilemap targetTilemap;
    [SerializeField] GameObject cropsSpritePrefab;

    Dictionary<Vector2Int, CropTile> crops;

    //quests
    public QuestGiver quest;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
        onTimeTick += Tick;
        Init();
    }

    public void Tick()
    {
        foreach (CropTile cropTile in crops.Values)
        {
            if(cropTile.crop == null) {
                readyMessage.SetActive(false);
                continue; }

            cropTile.damage += 0.02f;

            if (cropTile.damage > 0.5f)
            {
                cropTile.Harvested();
                targetTilemap.SetTile(cropTile.position, plowed);
                continue;
            }

            if (cropTile.Complete)
            {
                Debug.Log("Pronto para colher");
                AudioManager.instance.Play(sfxCompleted);
                readyMessage.SetActive(true);
                continue;
            }

            cropTile.growTimer += 1;

            if(cropTile.growTimer>=cropTile.crop.growthStageTime[cropTile.growStage])
            {
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];

                cropTile.growStage += 1;
                
            }
        }
    }
    
    public bool Check(Vector3Int posititon)
    {
        return crops.ContainsKey((Vector2Int)posititon);
    }

    public void Plow(Vector3Int position)
    {
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }
        AudioManager.instance.Play(sfxPlow);
        CreatePlowedTile(position);
        if (quest.quest.isActive)
        {
            Debug.Log("qualquer coisa " + quest.quest.goal.currentAmount);
            quest.quest.goal.ItemPlowed();
            if (quest.quest.goal.IsReached())
            {
                quest.quest.Complete();
            }
        }
    }

    public void Seed(Vector3Int position,Crop toSeed)
    {
        targetTilemap.SetTile(position, seeded);

        crops[(Vector2Int)position].crop = toSeed;
        if (quest.quest.isActive)
        {
            Debug.Log("qualquer coisa " + quest.quest.goal.currentAmount);
            quest.quest.goal.ItemPlanted();
            if (quest.quest.goal.IsReached())
            {
                quest.quest.Complete();
            }
        }
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        GameObject go = Instantiate(cropsSpritePrefab);
        go.transform.position = targetTilemap.CellToWorld(position);
        go.transform.position -= Vector3.forward*0.01f;
        go.SetActive(false);
        crop.renderer = go.GetComponent<SpriteRenderer>();

        crop.position = position;

        targetTilemap.SetTile(position, plowed);
    }
    internal void PickUp(Vector3Int gridPosition)
    {
        Vector2Int position = (Vector2Int)gridPosition;
        if(crops.ContainsKey(position) == false) { return; }

        CropTile cropTile = crops[position];

        if (cropTile.Complete)
        {
            ItemSpawnManager.instance.SpawnItem(
                targetTilemap.CellToWorld(gridPosition),
                cropTile.crop.yield,
                cropTile.crop.count
                );

            targetTilemap.SetTile(gridPosition, plowed);
            cropTile.Harvested();
            if (quest.quest.isActive)
            {
                Debug.Log("qualquer coisa " + quest.quest.goal.currentAmount);
                quest.quest.goal.ItemHarvested();
                if (quest.quest.goal.IsReached())
                {
                    quest.quest.Complete();
                }
            }
        }
    }
}
