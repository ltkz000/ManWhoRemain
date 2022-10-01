using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
    public Transform transform;
    public Transform player;
    public GameObject botPrefab;
    public Queue<GameObject> botQueue;
    private float xPos;
    private float zPos;
    private int enemyCount;
    [SerializeField] private int poolSize;

    private void Start() 
    {
        botQueue = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = GenerateNewBot();
            botQueue.Enqueue(gameObject);
        }
    }

    public GameObject GenerateNewBot()
    {
        GameObject gameObject = Instantiate(botPrefab);
        gameObject.SetActive(false);
        gameObject.transform.parent = transform;
        return gameObject;
    }

    public void SpawnBotFromPool()
    {   
        while(enemyCount < 10)
        {
            
        }
    }

    public void ReturnBotToPool()
    {

    }
}
