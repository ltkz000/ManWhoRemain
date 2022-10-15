using System.Collections.Generic;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
    public Transform transform;
    public Transform player;
    public GameObject botPrefab;
    private Queue<GameObject> botQueue;
    public LayerMask groundLayer;
    private float xPos;
    private float zPos;
    [SerializeField] private int enemyCount;
    [SerializeField] private int botAlive;
    [SerializeField] private int poolSize;

    private void Start() 
    {
        botQueue = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject newBot = GenerateNewBot();

            // Character botScript = newBot.GetComponent<Character>();
            botQueue.Enqueue(newBot);
        }
    }

    public GameObject GenerateNewBot()
    {
        GameObject gameObject = Instantiate(botPrefab);
        gameObject.SetActive(false);
        gameObject.transform.position = player.position;
        gameObject.transform.parent = transform;
        return gameObject;
    }

    public void SpawnBotFromPool()
    {   
        while(enemyCount < 7 && botAlive > 10)
        {
            Vector3 playerPos = player.position;
            Vector3 spawnPos;

            playerPos = player.position;
            Vector2 randomPos = Random.insideUnitCircle.normalized;
            int randomRange = Random.Range(10, 40);
            xPos = randomPos.x * randomRange;
            zPos = randomPos.y * randomRange;

            spawnPos = new Vector3(playerPos.x + xPos, playerPos.y, playerPos.z + zPos); 

            if(Physics.Raycast(spawnPos, -player.transform.up, Mathf.Infinity, groundLayer))
            {
                GameObject objectToSpawn = botQueue.Dequeue();
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.position = spawnPos;

                Character botScript = objectToSpawn.GetComponent<Character>();
                botScript.BotOnSpawn();
                enemyCount++;
            }
        }
    }
    public void ReturnBotToPool(GameObject returnedBot)
    {
        botQueue.Enqueue(returnedBot);
        enemyCount--;
        botAlive--;
    }

    public int GetBotAlive()
    {
        return botAlive;
    }
}
