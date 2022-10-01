using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {MainMenu, GamePlay, Pause, Result}

public class GameManager : Singleton<GameManager>
{
    public GameState currentgameState;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = true;

        currentgameState = GameState.Pause;
    }

    public void ChangeState(GameState gameState)
    {
        currentgameState = gameState;
    }

    public bool IsState(GameState gameState)
    {
        return this.currentgameState == gameState;
    }
}
