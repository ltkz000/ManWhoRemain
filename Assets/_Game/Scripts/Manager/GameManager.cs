using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public enum GameState {MainMenu, GamePlay, Pause, Result, SkinShop}

public class GameManager : Singleton<GameManager>
{
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

    public bool IsState(GameState gameState)
    {
        return this.currentgameState == gameState;
    }

    public void BackToMainMenu()
    {
        BotManager.Ins.Restart();
        CameraController.Ins.Restart();
        PlayerDataManager.Ins.SpawnPlayer();
    }
}
