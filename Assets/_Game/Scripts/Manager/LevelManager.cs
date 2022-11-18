using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform levelManagerTrans;
    [SerializeField] private LevelData levelData;

    public Dictionary<int, GameObject> levelMapDict = new Dictionary<int, GameObject>();

    public GameObject GetMap(int level)
    {
        if(!levelMapDict.ContainsKey(level) || levelMapDict[level] == null)
        {
            GameObject map = Instantiate(levelData.GetLevelMapData(level),levelManagerTrans);
            levelMapDict[level] = map;
        }

        return levelMapDict[level];
    }

    public GameObject OpenMap(int level)
    {
        GameObject map = GetMap(level);
        map.SetActive(true);
        return map;
    }

    public void CloseMap(int level)
    {
        if(IsMapOpened(level))
        {
            Debug.Log(GetMap(level).name);
            GetMap(level).SetActive(false);
        }
    }

    public bool IsMapOpened(int level)
    {
        // return levelData.GetLevelMapData(level) != null && levelData.GetLevelMapData(level).activeInHierarchy;
        return levelData.GetLevelMapData(level) != null;
    }

    public int GetMaxLevel()
    {
        return levelData.GetMaxMap() - 1;
    }
}
