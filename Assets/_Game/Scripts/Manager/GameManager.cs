using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // if(levelList[levelIndex - 1] != null)
        // {
        //     levelList[levelIndex - 1].SetActive(false);
        // }
        if(levelList[levelIndex] != null)
        {
            levelList[levelIndex].SetActive(true);
        }
    }

    public bool IsState(GameState gameState)
    {
        return this.currentgameState == gameState;
    }
}
