using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Level Data")]

public class LevelData : ScriptableObject
{
    [SerializeField, NonReorderable] private List<Level> levelList;

    public int GetBotOnTimeData(int levelIndex)
    {
        return levelList[levelIndex].botOnTime;
    }

    public int GetBotAliveData(int levelIndex)
    {
        return levelList[levelIndex].botAlive;
    }

    public int GetPoolSizeData(int levelIndex)
    {
        return levelList[levelIndex].poolSize;
    }

    public GameObject GetLevelMapData(int levelIndex)
    {
        return levelList[levelIndex].levelMap;
    }

    public int GetMaxMap()
    {
        return levelList.Count;
    }
}

[System.Serializable]
public class Level
{
    public int botAlive;
    public int botOnTime;
    public int poolSize;
    public GameObject levelMap;
}

