using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public enum GameState {MainMenu, GamePlay, Pause, Result, SkinShop}

public class GameManager : Singleton<GameManager>
{
    [SerializeField, NonReorderable] private List<GameObject> levelList;
    public GameState currentgameState;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = true;

        currentgameState = GameState.MainMenu;
    }

    public void ChangeState(GameState gameState)
    {
        this.currentgameState = gameState;
    }

    public void OpenGameLevel(int levelIndex)
    {
        Debug.Log(levelList[levelIndex].name);
        for(int i = 0; i < levelList.Count; i++)
        {
            if(i != levelIndex)
            {
                levelList[i].SetActive(false);
            }
            else
            {
                levelList[i].SetActive(true);
            }
        }
        NavMeshBuilder.BuildNavMesh();
    }

    public int GetMaxLevel()
    {
        return levelList.Count - 1;
    }

    public bool IsState(GameState gameState)
    {
        return this.currentgameState == gameState;
    }
}
