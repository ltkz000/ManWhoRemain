using System.Collections.Generic;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
    [SerializeField] LevelData levelData;
    public Transform botParentTranform;
    public Transform playerTrans;
    public Character botPrefab;
    private Queue<Character> botQueue;
    public LayerMask groundLayer;
    private float xPos;
    private float zPos;
    [SerializeField] private List<Character> spawnedList;
    [SerializeField] private int enemyCount;
    [SerializeField] private int botAlive;
    [SerializeField] private int botOnTime;
    [SerializeField] private int poolSize;

    private void Start() 
    {
        Init();
    }

    public void Init()
    {
        enemyCount = 0;
        botOnTime = levelData.GetBotOnTimeData(PlayerDataManager.Ins.GetPlayerLevel());
        botAlive = levelData.GetBotAliveData(PlayerDataManager.Ins.GetPlayerLevel());
        playerTrans = PlayerDataManager.Ins.GetCharacterCombat().GetCharacterTranform();

        botQueue = new Queue<Character>();

        for(int i = 0; i < poolSize; i++)
        {
            Character newBot = GenerateNewBot();

            botQueue.Enqueue(newBot);
        }
    }

    public Character GenerateNewBot()
    {
        Character character = Instantiate(botPrefab);
        character.gameObject.SetActive(false);
        character.GetCharacterTranform().position = playerTrans.position;
        character.GetCharacterTranform().parent = botParentTranform;
        return character;
    }

    public void SpawnBotFromPool()
    {   
        if(playerTrans == null)
        {
            playerTrans = PlayerDataManager.Ins.GetCharacterCombat().GetCharacterTranform();
        }
        while(enemyCount < botOnTime && botAlive >= botOnTime)
        {
            Vector3 playerPos = playerTrans.position;
            Vector3 spawnPos;

            playerPos = playerTrans.position;
            Vector2 randomPos = Random.insideUnitCircle.normalized;
            int randomRange = Random.Range(10, 45);
            xPos = randomPos.x * randomRange;
            zPos = randomPos.y * randomRange;

            spawnPos = new Vector3(playerPos.x + xPos, playerPos.y, playerPos.z + zPos); 

            if(Physics.Raycast(spawnPos, -playerTrans.up, Mathf.Infinity, groundLayer))
            {
                if(botQueue.Count == 0)
                {
                    Character newBot = GenerateNewBot();
                    botQueue.Enqueue(newBot);
                }

                Character objectToSpawn = botQueue.Dequeue();
                spawnedList.Add(objectToSpawn);
                objectToSpawn.gameObject.SetActive(true);
                objectToSpawn.GetCharacterTranform().position = spawnPos;
                objectToSpawn.BotOnSpawn();

                enemyCount++;
            }
        }
    }
   
    public void ReturnBotToPool(Character returnedBot)
    {
        spawnedList.Remove(returnedBot);
        botQueue.Enqueue(returnedBot);
    }

    public void Restart()
    {
        for(int i = 0; i < spawnedList.Count; i++)
        {
            Destroy(spawnedList[i].gameObject);
        }
        spawnedList.Clear();

        foreach(Character temp in botQueue)
        {
            Destroy(temp.gameObject);
        }
        botQueue.Clear();

        Init();
    }
    
    public int GetBotAlive()
    {
        return botAlive;
    }

    public void BotDead()
    {
        botAlive--;
        enemyCount--;
    }
}
